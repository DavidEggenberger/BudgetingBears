using System;
using System.Collections.Generic;

namespace APITypes
{
    public class Parameters
    {
        public string dataset { get; set; }
        public string timezone { get; set; }
        public int rows { get; set; }
        public int start { get; set; }
        public string format { get; set; }
        public List<string> facet { get; set; }
    }
    public class Fields
    {
        public string konto { get; set; }
        public string titel_nr { get; set; }
        public int budget_2021 { get; set; }
        public int budget_2020 { get; set; }
        public double rechnung_2019 { get; set; }
        public string aufwand_ertrag { get; set; }
        public int abweichung_vom_vorjahresbudget { get; set; }
        public string ebene_2 { get; set; }
        public string ebene_1 { get; set; }
        public string zeilennummer { get; set; }
        public string kontotitel { get; set; }
        public string kontostruktur { get; set; }
        public string typ { get; set; }
    }
    public class Record
    {
        public string datasetid { get; set; }
        public string recordid { get; set; }
        public Fields fields { get; set; }
        public DateTime record_timestamp { get; set; }
    }
    public class Facet
    {
        public int count { get; set; }
        public string path { get; set; }
        public string state { get; set; }
        public string name { get; set; }
    }
    public class FacetGroup
    {
        public List<Facet> facets { get; set; }
        public string name { get; set; }
    }
    public class Root
    {
        public int nhits { get; set; }
        public Parameters parameters { get; set; }
        public List<Record> records { get; set; }
        public List<FacetGroup> facet_groups { get; set; }
    }
}
