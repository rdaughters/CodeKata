# Welcome to Tim's Terrific Travel Tally!
Tim loves to go on adventures. He also loves data and keeping track of specific data about all the grand travels he's been on. As a result, 
Tim created an iOS mobile app he likes to call "Tim's Terrific Travel Tally". The app is pretty simple in it's design. It has a main page
that displays a list of different travel tallies (also called travel logs, but if he called it that then the alteration would be broken, which
would really be a bummer). Clicking on a travel tally will bring you to the Travel Details Page. On this page, you'll see the title of the travel
tally at the top, and then a list of Drivers for that travel period. Each Driver will have additional details displayed about the total miles 
driven and the average speed at which the driver drove. From the Travel Details page you can hit the back button to take you back to the 
main page to select the same or different travel tally.

## Introduction
Thanks for the opportunity to tackle your code kata! Hopefully you enjoyed my silly introduction to Tim's new app, he's pretty proud of it. All joking aside, I wanted to take the fairly simple challenge presented to me and format it into a more "real life example" that would allow me to showcase how I would
implement different software design patterns. Hopefully this little app will you give you a better idea of the type of work I would bring to 
your enterprise level applications.

## Design Decisions
#### 1. MVVM
As I was developing a Xamarin Forms application, I chose to follow the MVVM design pattern. Obviously this is pretty standard design pattern to follow when using forms, and also a pattern I am very familiar with from working on a WPF application in my current role. This gives me the benefits of having seperation of concern between my views and my viewmodesl, always reuse of any views if the need ever arose, and gave me opportunity to unit test my viewmodels and models.

#### 2. Dependency Injection
I took advantage of DI in two places in my app. First with the creation of the ITravelLogStore interface. This interface contains one fuction called GetTravelLogs which returns a list of TravelLog objects. A TravelLog object contains a title and a Log property of type string that contains the text of commands. I created a class called TravelLogProcessor that implements this interface by reading embedded text files and producing the list of TravelLog objects. This interface is passed as a parameter to my MainPageViewModel and a call to GetTravelLogs is used to populate the list of "Travel Tallies". The advantage to all this is that if in the future the app needed to call some web service to retrieve the travel logs instead of using embedded text files then this can simply be accomplished by creating a new class that implements the ITravelLogStore, make the neccessary calls to the web service, and pass this class to the MainPageViewModel instead and everything continues to work.

Similarly, I created an interface called ITravelLogProcessor with one function called ProcessTravelLog that processes the Log string from a TravelLog object. Again, the advantage of this is that I implemented one way of processing the commands now, but if this would ever need to change, it can be accomplished easily by creating a different subclass of ITravelLogProcessor and implementing the new approach. 

Additionally, decoupling loading TraveLogs and processing travel logs from the respective MainPageViewModel and TravelDetailsViewModel enables the logic to be reused easily in other parts of the program.

## Adding Your Own Input File
If you want to add your own input file first add the file to the "CodeKata.Files" folder. Then in TravelLogStore.cs in the GetTravelLogs method, copy and paste the following under the "// add more logs here and follow pattern above" comment:

```
TravelLog newLog = new TravelLog("{name of log}");
newLog.Log = await ReadTravelLog("{name of text file}.txt");
logs.Add(newLog);
```
Where {name of log} is the title of log and {name of text file} is the name of the text file you added.

## Notes
One small bug I am aware of but didn't spend the time trying to resolve because I wanted to focus more on the overal design and implementation, is that if you view the app in landscape mode, the picture doesn't fill the whole screen. My guess is I didn't get a large enough pixel resolution image to accomedate landscape mode.

## Final Thoughts
I hope you enjoy Tim's Terrific Travel Tally app, and I hope we get the chance to talk further! Thanks!
