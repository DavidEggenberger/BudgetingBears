using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class SolutionDesired
    {
        public Guid Id { get; set; }
        public string SID { get; set; }
        public string UserName { get; set; }
        public List<Account> OrderofAccounts { get; set; }
        public List<VoteToOrdering> Votes { get; set; }
        public List<CommentToOrdering> Comments { get; set; }

    }
    public class Account
    {
        public Guid Id { get; set; }
        public string konto { get; set; }
        public string titel_nr { get; set; }
        [Column(TypeName = "decimal(26, 6)")]
        public decimal budget_2021 { get; set; }
        [Column(TypeName = "decimal(26, 6)")]
        public decimal budget_2020 { get; set; }
        [Column(TypeName = "decimal(26, 6)")]
        public decimal rechnung_2019 { get; set; }
        public string aufwandertrag { get; set; }
        public int abweichungvomvorjahresbudget { get; set; }
        public string ebene2 { get; set; }
        public string ebene1 { get; set; }
        public string zeilennummer { get; set; }
        public string kontotitel { get; set; }
        public string kontostruktur { get; set; }
        public string typ { get; set; }
    }
    public class VoteToOrdering
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string SID { get; set; }
    }
    public class CommentToOrdering
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string SID { get; set; }
        public string UserName { get; set; }
    }
    public class Post
    {
        public Guid PostId { get; set; }
        public string Level1Name { get; set; }
        public int CountOfAccounts { get; set; }
        [Column(TypeName = "decimal(26, 6)")]
        public decimal Cost2019 { get; set; }
        [Column(TypeName = "decimal(26, 6)")]
        public decimal Budget2020 { get; set; }
        [Column(TypeName = "decimal(26, 6)")]
        public decimal Budget2021 { get; set; }
        [Column(TypeName = "decimal(26, 6)")]
        public decimal ChangeToPrevious { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Vote> Votes { get; set; }
    }
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
    public class Vote
    {
        public Guid VoteId { get; set; }
    }
}
