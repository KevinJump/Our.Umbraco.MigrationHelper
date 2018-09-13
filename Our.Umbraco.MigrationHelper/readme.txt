
Migration Helper for Umbraco 
============================

A Simple tool to make an amazing thing simpler. 

1. Create a class that impliments IUmbracoApp :

    public class MyUmbracoApp : IUmbracoApp
	{
        public string Name => "Jumoo.MyUmbracoApp";
        public string Version => "1.0.0";
	}

2. And any migrations with for that app: 

    [Migration("1.0.0", 1, "Jumoo.MyUmbracoApp")]

will be ran upto the version in your IUmbracoApp class.  


