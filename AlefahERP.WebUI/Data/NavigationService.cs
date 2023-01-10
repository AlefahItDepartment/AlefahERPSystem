namespace AlefahERP.WebUI.Data
{
    public class NavigationService
    {
        Navigation[] allNavigations = new[] {


            new Navigation
            {
                 Name  = "Dashbaord",
                 Path ="/",
                 Icon="dashboard",
                 New=true, 
                 Updated=true,

            },
               new Navigation {

                Name="Pet Care",
                Icon="pets",
                Children = new []
                {
                    new Navigation {

                        Name="Appointments",
                        Path="/appointments",
                        Icon="recent_actors"

                    }
                }

            },
               new Navigation {

                Name="HR Management",
                Icon="groups",
                Children = new []
                {
                    new Navigation {

                        Name="Employees",
                        Path="/employees",
                        Icon="people"

                    }
                }

            },
            new Navigation {

                Name="Setup",
                Icon="build",
                Children = new []
                {
                    new Navigation { 
                        
                        Name="Department",
                        Path="/department",
                        Icon="reduce_capacity"

                    },
                     new Navigation {

                        Name="Designation",
                        Path="/designation",
                        Icon="contact_page"

                    },
                    new Navigation {

                        Name="Pet Care",                       
                        Icon="pets",

                        Children = new []
                        {
                            new Navigation
                            {
                                Name="Pet Species",
                                Path="/petspecies"

                            },
                            new Navigation
                            {
                                Name="Pet Sub Species",
                                Path="/petsubspecies"

                            },
                            new Navigation
                            {
                                Name="Pet Breeds",
                                Path="/petbreeds"

                            },
                            new Navigation
                            {
                                Name="Pet Colors",
                                Path="/petcolors"

                            },
                            new Navigation
                            {
                                Name="Pet Sizes",
                                Path="/petsizes"

                            },
                            new Navigation
                            {
                                Name="Pet Origin",
                                Path="/petorigins"

                            },
                            new Navigation
                            {
                                Name="Blood Chemistry Types",
                                Path="/petbloodchemistrytypes"

                            },
                            new Navigation
                            {
                                Name="Blood Chemistry Details",
                                Path="/petbloodchemistrydetails"

                            },
                            new Navigation
                            {
                                Name="Blood Screen Types",
                                Path="/petbloodscreentypes"

                            },
                            new Navigation
                            {
                                Name="Blood Screen Details",
                                Path="/petbloodscreendetails"

                            },
                            new Navigation
                            {
                                Name="Examine Types",
                                Path="/petexaminetypes"

                            },
                            new Navigation
                            {
                                Name="Examine Details",
                                Path="/petexaminedetails"

                            }

                        }

                    },
                     new Navigation {

                        Name="Country",
                        Path="/country",

                    },
                      new Navigation {

                        Name="Region",
                        Path="/region",

                    },
                      new Navigation {

                        Name="City",
                        Path="/city",

                    }, new Navigation {

                        Name="Booking Status",
                        Path="/bookingstatus"

                    },

                }
                
            },new Navigation {

                Name="Settings",
                Icon="settings",
                Children = new []
                {
                    new Navigation {

                        Name="Menu3",
                        Path="/Menu3",
                        Icon="dashboard"

                    },
                    new Navigation {

                        Name="Menu4",
                        Path="/Menu4",
                        Icon="dashboard"

                    }

                }

            }
        };

        public IEnumerable<Navigation> Navigations
        {
            get
            {
                return allNavigations;
            }
        }

        public IEnumerable<Navigation> Filter(string term)
        {
            if (string.IsNullOrEmpty(term))
                return allNavigations;

            bool contains(string value) => value != null && value.Contains(term, StringComparison.OrdinalIgnoreCase);

            bool filter(Navigation example) => contains(example.Name) || (example.Tags != null && example.Tags.Any(contains));

            bool deepFilter(Navigation example) => filter(example) || example.Children?.Any(filter) == true;

            return Navigations.Where(category => category.Children?.Any(deepFilter) == true || filter(category))
                           .Select(category => new Navigation
                           {
                               Name = category.Name,
                               Path = category.Path,
                               Icon = category.Icon,
                               Expanded = true,
                               Children = category.Children?.Where(deepFilter).Select(example => new Navigation
                               {
                                   Name = example.Name,
                                   Path = example.Path,
                                   Icon = example.Icon,
                                   Expanded = true,
                                   Children = example.Children
                               }
                               ).ToArray()
                           }).ToList();
        }

        //public Navigation FindCurrent(Uri uri)
        //{
        //    //IEnumerable<Navigation> Flatten(IEnumerable<Navigation> e)
        //    //{
        //    //    return e.SelectMany(c => c.Children != null ? Flatten(c.Children) : new[] { c });
        //    //}

        //    //return Flatten(Navigations)
        //    //            .FirstOrDefault(example => example.Path == uri.AbsolutePath || $"/{example.Path}" == uri.AbsolutePath);
        //}

    }
}
