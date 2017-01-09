BeekeepersCorner

Beekeepers registration and records keeping site. This site is not not just a code demostration but is intended to eventually be bublicaly hosted and used by beekeepers.

This site allows a beekeeper to stay in contact with other beekeepers and record information on thier beehives. The site is built with MVC 5 and Microsoft .NET Core 1.0.x with Visual Studeo 2015 Comunity version. The database management is built on Entity Framework 6 with "code first" design. At this point, the site has a standard MVC Web site located at [localhost]/beekeepers/beekeepers and an Angular JS 1 version located at [localhost]/beekeepers/beekeepersaj. The Angular JS version of the site uses different controller methods and views as indicated in the project folders.

TODO list:

Add authentication and control view/edit rights for each beekeeper.

Add in a "bee yard" layer over the beehives layer with GPS coordinates to group beehives in relation to other yards.

Improve record keeping on beehives for honey production and other statistics and provide reporting.

Split Beekeepers Corner project into three separate projects: MVC Web project, Angular JS Web site, and business layer project with Entity Framework.  This will prevent javascript file conflicts in the Web site code.
