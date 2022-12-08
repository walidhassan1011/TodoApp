
# TodoApp

this app is a simple TodoApp with a .net core server and postgresssql database and front-end library react js


## Features

- add todos
- change todos status 



## Installation
clone the repo and after add the following command

```bash
  cd .\TodoApp\
  yarn 
  yarn dev
```
To run the .net server use the start without debugging 

add your own pass and database name in the appsettings.json
```bash
   "postgresConnection": "Server=localhost;Database=YOUR_DATABASE_NAME;Port=5432;User Id=postgres;Password=YOUR_OWN_PASS;"
```
## API Reference

#### Get all Todos

```https
  GET /api/TodoItems
```

#### Get Todo

```https
  GET /api/TodoItems/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |

### POST Todo

```https
  POST /api/TodoItems
```

#### Edit Todo

```https
  PUT /api/TodoItems/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |


#### Delete Todo

```https
  DELETE /api/TodoItems/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |
# TodoApp

 ### swaagger 
![api swaagger](https://user-images.githubusercontent.com/95965261/206424720-faf504c0-4230-4e36-9f21-025d055309d6.png)
### user interface 
![user interface](https://user-images.githubusercontent.com/95965261/206425885-35a8de1f-b80e-4685-a00c-f5777f47d051.png)
### add todo 
![add todo ](https://user-images.githubusercontent.com/95965261/206426180-3120f2fe-009e-4ee0-b0da-ac3ba23acb60.png)
## 🔗 Links
[![portfolio](https://img.shields.io/badge/my_portfolio-000?style=for-the-badge&logo=ko-fi&logoColor=white)](https://walid-portfolio.vercel.app/)
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/walid-hassan-a744461a7/)
[![twitter](https://img.shields.io/badge/twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white)](https://twitter.com/Walidhassan111)

