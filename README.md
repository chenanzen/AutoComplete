# AutoComplete
This project show an implementation of autocomplete on a textbox input. Data source used is GitHub Search Topics API (https://docs.github.com/en/rest/search#search-topics).

You can view a demo of this project in following URL: https://cazautocomplete.azurewebsites.net/
NOTE: Azure Web App and GitHub API are both on free tier.

## Opening The Project
1. Please download and [Visual Studio Community 2022](https://visualstudio.microsoft.com/vs/). 
2. Clone repo and open AutoComplete.sln in sourcecode folder with Visual Studio.
3. Update token in config file
4. Click Run

## Dependencies
1. JQuery-UI: This library is UI library to construct *AutoComplete* based on JQuery library
2. RestSharp: This is nuget library to support consuming REST Web API
3. GitHub Search API: This is end point that is used as data source of auto complete
