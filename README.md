# clean-architecture
> For everyone who wants to learn Clean Architecture :fire:


The objective of this project was to develop an application that has separation of concerns.
Dividing the software into the following layers:
- [x] Domain 🥰
- [x] App 😎
- [x] Infra.Data 😤
- [x] Infra.Ioc 🤖
- [x] WebAPI 👽

Each layer has its responsibility. The Domain Layer is the innermost layer imagined as a circle, it is where our entities that contain the business rules are located, this layer does not know the outermost layers. Next, we have the Application that will implement the system use cases, which by the way is not affected by externalities such as the database, UI or any framework, later we will have the outermost layers where it is usually composed of a web framework (WebApi) and database (Infra.Data).
