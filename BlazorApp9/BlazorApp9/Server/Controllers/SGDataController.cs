using APITypes;
using Data;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp9.Server.Controllers
{
    public class Dto
    {
        public string Level1Name { get; set; }
    }
    public class CommentDTO
    {
        public string Text { get; set; }
        public string Title { get; set; }
        public string Level1Name { get; set; }
    }
    [Route("/[controller]")]
    [ApiController]
    public class SGDataController : ControllerBase
    {
        SGClient sgClient;
        DataContext context;
        public SGDataController(SGClient factory, DataContext conte)
        {
            sgClient = factory;
            context = conte;
        }
        public async Task<List<Post>> GetPosts()
        {
            return await context.Posts.ToListAsync();
        }
        [HttpPost]
        [Route("Comment")]
        public async Task<ActionResult> AddToComment(CommentDTO dto)
        {
            Post post = context.Posts.Where(s => s.Level1Name == dto.Level1Name).First();
            post.Comments = new List<Comment>();
            post.Comments.Add(new Comment { Text = dto.Text, Title = dto.Title });
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("level")]
        public async Task<ActionResult> GetLevel(Dto dt)
        {
            var resp = context.Posts.Include(s => s.Comments).Include(s => s.Votes).Where(s => s.Level1Name == dt.Level1Name).FirstOrDefault();
            return Ok(resp);
        }
        [Route("DirectCallFromAPI")]
        public async Task<IEnumerable<object>> GetAllDataDirectFromSGAPI()
        {
            return (await sgClient.GetStringAsync()).GroupBy(s => s.records.First().fields.ebene_1)
                .Select(s => 
                new { 
                    Level1 = s.Key, 
                    Count = s.Count(), 
                    Cost2019 = s.Select(f => f.records.Select(u => u.fields.rechnung_2019).Sum()).Sum(), 
                    Budget2020 = s.Select(f => f.records.Select(u => u.fields.budget_2020).Sum()).Sum(),
                    Budget2021 = s.Select(f => f.records.Select(u => u.fields.budget_2021).Sum()).Sum(),
                    ChangeToPrevious = s.Select(f => f.records.Select(u => u.fields.abweichung_vom_vorjahresbudget).Sum()).Sum(),
                });
            //return (await sgClient.GetStringAsync()).records.Select(s => new { s.fields.kontotitel, s.fields.rechnung_2019 });
        }
        [Route("EFCore")]
        public async Task<IEnumerable<object>> Initi([FromServices] DataContext context)
        {
            foreach (var item in context.Posts)
            {
                context.Posts.Remove(item);
            }
            await context.SaveChangesAsync();
            var t = (await sgClient.GetStringAsync()).GroupBy(s => s.records.First().fields.ebene_1)
                .Select(s =>
                new {
                    Level1 = s.Key,
                    Count = s.SelectMany(t => t.records).Count(),
                    Cost2019 = s.Select(f => f.records.Select(u => u.fields.rechnung_2019).Sum()).Sum(),
                    Budget2020 = s.Select(f => f.records.Select(u => u.fields.budget_2020).Sum()).Sum(),
                    Budget2021 = s.Select(f => f.records.Select(u => u.fields.budget_2021).Sum()).Sum(),
                    ChangeToPrevious = s.Select(f => f.records.Select(u => u.fields.abweichung_vom_vorjahresbudget).Sum()).Sum(),
                });
            foreach (var item in t)
            {
                context.Posts.Add(new Post
                {
                    Budget2020 = item.Budget2020,
                    Budget2021 = item.Budget2021,
                    Cost2019 = (decimal)item.Cost2019,
                    Level1Name = item.Level1,
                    ChangeToPrevious = item.ChangeToPrevious,
                    CountOfAccounts = item.Count
                });
            }
            await context.SaveChangesAsync();
            return new string[] { "" };
        }
        [Route("GetThemAccounts")]
        public async Task<List<Entities.Account>> Getthem() => await context.Accounts.ToListAsync();
        [Route("EFCoreAccounts")]
        public async Task<IEnumerable<object>> InitAccounts([FromServices] DataContext context)
        {
            //foreach (var item in context.Posts)
            //{
            //    context.Posts.Remove(item);
            //}
            //await context.SaveChangesAsync();
            var t = (await sgClient.GetStringAsync())
                .SelectMany(s => s.records);
            foreach (var item in t)
            {
                context.Accounts.Add(new Entities.Account
                {
                    budget_2020 = item.fields.budget_2020,
                    budget_2021 = item.fields.budget_2021,
                    ebene1 = item.fields.ebene_1,
                    ebene2 = item.fields.ebene_2,
                    kontotitel = item.fields.typ,
                    aufwandertrag = item.fields.aufwand_ertrag,
                    rechnung_2019 = (decimal)item.fields.rechnung_2019,
                    konto = item.fields.konto,
                    typ = item.fields.typ,
                    kontostruktur = item.fields.kontostruktur,
                    titel_nr = item.fields.titel_nr,
                    zeilennummer = item.fields.zeilennummer,
                    abweichungvomvorjahresbudget = item.fields.abweichung_vom_vorjahresbudget
                });
            }
            await context.SaveChangesAsync();
            return new string[] { "" };
        }
        [HttpGet("AccountsRND")]
        public async Task<ActionResult> RandomizeAccounts()
        {
            return Ok(context.Accounts.ToList().OrderBy(s => new Random().Next()).Take(10));
        }
    }  
}
