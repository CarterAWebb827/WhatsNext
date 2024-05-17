<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a name="readme-top"></a>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<h3 align="center">Whats Next</h3>

  <p align="center">
    This is an application designed to help you figure out what anime you might want to watch next based off of a show that you just watched. This project is created using Visual Studio, C#, and XAML. I used a Console App for the gathering of information, while I used a WPF (Windows Presentation Format) app to create a GUI for this program.
    <br />
    <a href="https://github.com/CarterAWebb827/WhatsNext"><strong>Explore the ReadMe »</strong></a>
    <br />
    <br />
    ·
    <a href="https://www.youtube.com/watch?v=saL8Bms1VtI">View Demo</a>
    ·
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#resources">Resources</a></li>
    <li><a href="#packages">Packages</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

Welcome to the Whats Next!

Whats Next is a C# application designed to provide personalized anime recommendations based on user preferences. It utilizes API calls and an Algorithm to analyze an anime and suggest other anime titles that align with the picked anime.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these steps

### Prerequisites
Some things you may need for the project include a terminal with access to Git. You also need Visual Studio 2022 installed.



### Installation
1. Clone the repo
   ```sh
   git clone https://github.com/CarterAWebb827/WhatsNext.git
   ```
2. Open the solution
   ```sh
   ./WhatsNext.sln
   ```
3. Run the program by pressing the green button in the top left - make sure it is set to "WhatsNextWPF"

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

Here I have an example video of what running Whats Next looks like:
[https://www.youtube.com/watch?v=saL8Bms1VtI](https://www.youtube.com/watch?v=saL8Bms1VtI)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- RESOURCES EXAMPLES -->
## Resources
### API
[https://docs.api.jikan.moe/](https://docs.api.jikan.moe/)
- Jikan provides the API for accessing anime data. This includes titles, genres, ratings, and more. I used this API to fetch information about the anime titles to incorporate it into my program.

### Libraries
[http://materialdesigninxaml.net/](http://materialdesigninxaml.net/)
- Material Design In XAML is a toolkit for making use of Google's Material Design HTML stlye inside of XAML. O ised this to create my WPF and it's GUI.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- PACKAGES EXAMPLES -->
## Packages
### JikanDotNet
[https://github.com/Ervie/jikan.net](https://github.com/Ervie/jikan.net)
- JikanDotNet is a .NET wrapper for the Jikan API. I used it to easily access anime data from Jikan.

### MaterialDesignColors
[https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit) 
- MaterialDesignColors is a part of the Material Design In XAML Toolkit. It provides a set of pre-defined colors following the Material Design guidelines for use in your WPF and UWP applications.

### MaterialDesignThemes
[https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit) 
- MaterialDesignThemes is a part of the Material Design In XAML Toolkit. It offers a collection of customizable controls, styles, and templates to create modern and visually appealing user interfaces in WPF and UWP applications.

### Newtonsoft.Json
[https://www.newtonsoft.com/json](https://www.newtonsoft.com/json)
- Newtonsoft.Json is a JSON framework for .NET. I used Newtonsoft.Json to serialize and deserialize JSON data in my app, making it easy to work with JSON-formatted data from various sources.

### HttpClientFactory
[https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-6.0](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-6.0)
- HttpClientFactory is a part of ASP.NET Core. It provides a flexible and extensible way to create and manage HttpClient instances in a .NET application.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See `MIT-LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Carter Webb - CarterAWebb827@gmail.com

Project Link: [https://github.com/CarterAWebb827/WhatsNext](https://github.com/CarterAWebb827/WhatsNext)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[license-shield]: https://img.shields.io/github/license/CarterAWebb827/WhatsNext.svg?style=for-the-badge
[license-url]: https://github.com/CarterAWebb827/WhatsNext/blob/main/MIT-LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/carter-webb-66b3661b4/