using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using APITypes;

namespace BlazorApp9.Server
{
    public class SGClient : HttpClient
    {
        public HttpClient Htp { get; }
        public SGClient(HttpClient htp)
        {
            Htp = htp;
        }
        public async Task<List<Root>> GetStringAsync()
        {
            Root root = await Htp.GetFromJsonAsync<Root>("https://daten.stadt.sg.ch/api/records/1.0/search/?dataset=budget-2021-stadt-stgallen-funktionale-gliederung-english-data&q=&rows=904&facet=typ&facet=aufwand_ertrag&facet=kontostruktur&facet=ebene_1&facet=ebene_2&facet=ebene_3&facet=konto&facet=kontotitel&refine.ebene_1=0+citizenship%2C+authorities%2C+administration");
            Root root1 = await Htp.GetFromJsonAsync<Root>("https://daten.stadt.sg.ch/api/records/1.0/search/?dataset=budget-2021-stadt-stgallen-funktionale-gliederung-english-data&q=&rows=904&facet=typ&facet=aufwand_ertrag&facet=kontostruktur&facet=ebene_1&facet=ebene_2&facet=ebene_3&facet=konto&facet=kontotitel&refine.ebene_1=1+Public+Safety");
            Root root2 = await Htp.GetFromJsonAsync<Root>("https://daten.stadt.sg.ch/api/records/1.0/search/?dataset=budget-2021-stadt-stgallen-funktionale-gliederung-english-data&q=&rows=904&facet=typ&facet=aufwand_ertrag&facet=kontostruktur&facet=ebene_1&facet=ebene_2&facet=ebene_3&facet=konto&facet=kontotitel&refine.ebene_1=2+education");
            Root root3 = await Htp.GetFromJsonAsync<Root>("https://daten.stadt.sg.ch/api/records/1.0/search/?dataset=budget-2021-stadt-stgallen-funktionale-gliederung-english-data&q=&rows=904&facet=typ&facet=aufwand_ertrag&facet=kontostruktur&facet=ebene_1&facet=ebene_2&facet=ebene_3&facet=konto&facet=kontotitel&refine.ebene_1=3+Culture+and+Leisure");
            Root root4 = await Htp.GetFromJsonAsync<Root>("https://daten.stadt.sg.ch/api/records/1.0/search/?dataset=budget-2021-stadt-stgallen-funktionale-gliederung-english-data&q=&rows=904&facet=typ&facet=aufwand_ertrag&facet=kontostruktur&facet=ebene_1&facet=ebene_2&facet=ebene_3&facet=konto&facet=kontotitel&refine.ebene_1=4+health");
            Root root5 = await Htp.GetFromJsonAsync<Root>("https://daten.stadt.sg.ch/api/records/1.0/search/?dataset=budget-2021-stadt-stgallen-funktionale-gliederung-english-data&q=&rows=904&facet=typ&facet=aufwand_ertrag&facet=kontostruktur&facet=ebene_1&facet=ebene_2&facet=ebene_3&facet=konto&facet=kontotitel&refine.ebene_1=5+Social+Welfare");
            Root root6 = await Htp.GetFromJsonAsync<Root>("https://daten.stadt.sg.ch/api/records/1.0/search/?dataset=budget-2021-stadt-stgallen-funktionale-gliederung-english-data&q=&rows=904&facet=typ&facet=aufwand_ertrag&facet=kontostruktur&facet=ebene_1&facet=ebene_2&facet=ebene_3&facet=konto&facet=kontotitel&refine.ebene_1=6+traffic");
            Root root7 = await Htp.GetFromJsonAsync<Root>("https://daten.stadt.sg.ch/api/records/1.0/search/?dataset=budget-2021-stadt-stgallen-funktionale-gliederung-english-data&q=&rows=904&facet=typ&facet=aufwand_ertrag&facet=kontostruktur&facet=ebene_1&facet=ebene_2&facet=ebene_3&facet=konto&facet=kontotitel&refine.ebene_1=7+Environment+and+spatial+planning");
            Root root8 = await Htp.GetFromJsonAsync<Root>("https://daten.stadt.sg.ch/api/records/1.0/search/?dataset=budget-2021-stadt-stgallen-funktionale-gliederung-english-data&q=&rows=904&facet=typ&facet=aufwand_ertrag&facet=kontostruktur&facet=ebene_1&facet=ebene_2&facet=ebene_3&facet=konto&facet=kontotitel&refine.ebene_1=8+economics");
            Root root9 = await Htp.GetFromJsonAsync<Root>("https://daten.stadt.sg.ch/api/records/1.0/search/?dataset=budget-2021-stadt-stgallen-funktionale-gliederung-english-data&q=&rows=904&facet=typ&facet=aufwand_ertrag&facet=kontostruktur&facet=ebene_1&facet=ebene_2&facet=ebene_3&facet=konto&facet=kontotitel&refine.ebene_1=9+Finances");
            return new List<Root> { root, root1, root2, root3, root4, root5, root6, root7, root8, root9 };
        }
    }
}
