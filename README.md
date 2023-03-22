# DanceSchoolApp
UI for this application is here: https://github.com/DanielPrzewozny/DanceSchoolManager

## 1.	Jenkins
## 2.	RabbitMQ
> work in progress
- Status of lesson
- Student status
- two queues: 

| Virtual Host | Exchange | Queue name |
| ------ | ------ | ------ |
| danceschool_data | nv.direct | nv.direct.student.lessonstates |
| danceschool_data | nv.direct | nv.direct.teacher.lessonstates |

## 3.	ElasticSearch
> work in progress
- Logs (cleanup_policy after 7 days)
## 4.	Redis
> work in progress
- User tokens
- ConnectionId (SignalR)
## 5.	MongoDB (or PostgrSQL) collections (or dbs)
> work in progress
- Users
- UserLessons
- Views
- Groups
- ClubCards
- Lessons
- ArchivedLessons

## 6. Docker

## Libraries used in project: 
> work in progress
- AutoMapper
- MongoDB.Driver 
- SignalR
- LINQ
