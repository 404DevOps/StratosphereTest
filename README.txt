Instructions: 
--------------------------------------------------------

- Open Solution in Visual Studio (i used 2022 Version)
  - All Frontend Code is in the "frontend" Project
  - All API Code is in the "webapi" Project
  - All Unit Tests are in the "webapi.Test" Project.

- copy mydb.db to C:/Temp/ or adjust Path in appsettings.json in order to use my Sample Data.
- Run App with F5
-> Navigate Browser to https://localhost:5002
--------------------------------------------------------
--------------------------------------------------------


Quick Overview: 
--------------------------------------------------------
-> HomePage is the Leaderboard which is a cached version received from the API which calculates it by looking at "Earned Points" Activities
(the cache is refreshed after 1 minute for testing Purposes).

-> To see Player Details, click on a Player Name.

-> On the Detail Page the Score calculation can be modified by using the DateTime Fields, only Activities within the given are calculated, empty fields count as DateTime.MinValue or DateTime.MaxValue respectively.

-> On the Activities Page all PlayerActivities are listed, by Typing a PlayerUUID into the InputField, a filter is applied.

-> On the Test Page it's possible to add new Activities and/or Players. Depending on what is selected in the DropDown, the input Fields change.
--------------------------------------------------------
--------------------------------------------------------
