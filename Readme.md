# Acme Draw Setup

To setup the draw website and integration tests we first need to run the following Sql-files on your local SqlExpress with integrated security
```
/Acme.Draw/Acme.Draw.Core/Sql/CreateSqlEntities.sql
/Acme.Draw/Acme.Draw.Core/Sql/CreateSqlEntitiesForTests.sql
```
Next we need to install node modules in the ```Acme.Draw/Acme.draw``` folder
```
npm install
```
Lastly open the ```/Acme.Draw.sln```
And start the project up

# Prequisites

  - .Net Core 2.0 SDK
  - .Sql Server Express 2008 or later


