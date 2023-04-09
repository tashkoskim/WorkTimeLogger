
# WorkTimeLogger

## Windows forms app for loging working time
This windows forms application is created as a help tool for logging time at work. There are predefined actions that can be logged: 
- Coding 
- Meetings 
- Breaks  

Also there are some predefined descriptions that appear in a comboBox and the user can choose instead of typing. You can easily copy a description just with clicking on it, and paste it somewhere else.  
In order not to manually run the application every day, it would be best to create a shortcut from the exe and put it in the startup folder.
The default start position of the applicaion is in the lower right corner (above the clock). But if you want you can move it accross the screen.

## The application
The application was developed in *.NET Framework 6.0* (C#) as a *windows forms application*. 
### Log files
At startup the application creates **CSV** file where all of the records are stored. This CSV file is created for the current day in the same folder where the application is located under these folders *CurrentYear/CurrentMonthNumber/dd_MM_yyyy_User.csv*. The folders are created automatically. Sample of the CSV log:
```csv
StartTime,EndTime,Duration,Date,Activity,Description
06:41,06:41,0,28.03.2023,Coding,Working on the task 1234
06:41,06:41,0,28.03.2023,Break,Break
06:41,-,0,28.03.2023,Meeting,Daily meeting with the local team.
```  
In the last line you can always see the character '-' for the endTime only if the user hasn't clicked on 'Finish for today!' (from the context menu strip). 
If the user clicks on 'Exit', the application is only closed. If you run it again it will continue from the current day log file. 

### Template descriptions
In the same folder with the application executable there is a file *template.json* that is used of the application in order to fill the comboBox with the most used descriptions (that way the user can choose without typing). The structure of the json file is simple:
```json
{
  "MostUsedPhrases": [
    "",
    "Working on the task ",
    "Daily meeting with the local team.",
    "Daily meeting with ",
    "Code refactoring",
    "Errors fixing"
  ]
}
```

## Screenshots
Screenshot of the application if the mouse cursor is not over it (the header is always above every active window):  
![Minimized](https://github.com/tashkoskim/WorkTimeLogger/blob/master/WorkTimeLogger/Screenshots/WorkTimeLogger_Minimized_v2.JPG?raw=true)   

Screenshot of the application if the mouse cursor is over the header panel:  
![Maximizied](https://github.com/tashkoskim/WorkTimeLogger/blob/master/WorkTimeLogger/Screenshots/WorkTimeLogger_Maximized_v2.JPG?raw=true)  

Screenshot of context menu strip (if you right click with the mouse on the icon):  
![Menu](https://github.com/tashkoskim/WorkTimeLogger/blob/master/WorkTimeLogger/Screenshots/WorkTimeLogger_ContextMenuStrip_v2.JPG?raw=true)  

Screenshot of the form where you can search every log and you can generate an excel report for a date period:  
![LogForm](https://github.com/tashkoskim/WorkTimeLogger/blob/master/WorkTimeLogger/Screenshots/WorkTimeLogger_LogHistory_v3.JPG?raw=true)  


### GIF demo of the application
In this demo you can see the whole process of how to add new record (coding, meeting or break), how the mouse hover the application works and how the whole design look:  
![WorkTimeLogger](https://github.com/tashkoskim/WorkTimeLogger/blob/master/WorkTimeLogger/Screenshots/WorkTimeLogger_v2.gif?raw=true) 


## Authors
- tashkoskim@yahoo.com

