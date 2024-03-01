# Команда 19. Сервис такси и личных водителей

| Состав команды |
|:-----|
| Федорин Кирилл Вячеславович |
| Шалунов Андрей Ильич |
| Ананьев Никита Владимирович |
| Малышев Сергей Александрович |
| Оспельников Алексей Владимирович |

## Kanban-доска
https://ooplabs.kaiten.ru/space/328957

## Доменные сущности

```json
{
  "Owner":{
    "IE": ["string", "not null", "lenght=15", "unique"],
    "Name": ["string"],
    "Phone": ["string"]
  },
  "Taxi":{
    "Name": ["string", "not null"],
    "Phone": ["string", "not null", "unique"],
    "Registration date": ["date"],
    "Owner": ["owner object"]
  },
  "Car Park":{
    "Address": ["string", "not null"],
    "Postcode": ["string"],
    "Car count": ["int", "not null", "default=0"]
  },
  "Driver":{
    "Name": ["string"],
    "Driver license": ["string", "unique", "not null"],
    "Passport": ["string", "not null", "unique"],
    "Phone": ["string", "unique"],
    "Email": ["string", "unique"]
  },
  "Passenger":{
    "Name": ["string"],
    "Phone": ["string", "unique", "not null"],
    "Email": ["string", "unique"]
  },
  "Order":{
    "Order type": [{"string": ["taxi", "personal driver service"]}],
    "Date": ["datetime"],
    "Driver": ["driver object"],
    "Passenger": ["passenger object"],
    "Price": ["int", "default=0"],
    "Driver rate": [{"int": "1-5"}],
    "Passenger rate": [{"int": "1-5"}]
  },
  "Time Worksheet":{
    "Taxi": ["taxi object"],
    "Driver": ["driver object"],
    "Date": ["date", "not null"],
    "Hourly salary": ["int", "default=0"],
    "Hours": ["int", "default=0"]
  },
  "Car":{
    "Car number": ["string", "unique", "not null"],
    "Brand": ["string"],
    "Model": ["string"],
    "Year": ["date"],
    "Car park": ["car park object"]
  },
  "Car Rent":{
    "Driver": ["driver object"],
    "Car": ["car object"],
    "Start date": ["date", "not null"],
    "End date": ["date"],
    "Daily price": ["int", "not null", "default=0"]
  }
}

```

## Методы работы

Создание заказчика - ```POST /api/v1/owners```\
request - ```{"IE": "string", "Name": "string", "Phone": "string"}```\
responce - ```{"ownerId": "4w5l6jn4wlk5j6nw4lk56"}```

Создание такси  - ```POST /api/v1/taxis```\
request - ```{"Name": "string", "Phone": "string", "RegistrationDate": "yyyy-mm-dd", "Owner": {"IE": "string", "Name": "string", "Phone": "string"}}```\
responce - ```{"taxiId": "4w5l6jn4wlk5j6nw4lk56"}```

Создание парка машин - ```POST /api/v1/car-parks```\
request - ```{"Address": "string", "Postcode": "string", "CarCount": 0}```\
responce - ```{"carParkId": "4w5l6jn4wlk5j6nw4lk56"}```

Добавление водителя - ```POST /api/v1/drivers```\
request - ```{"Name": "string", "DriverLicense": "string", "Passport": "string", "Phone": "string", "Email": "string"}```\
responce - ```{"driverId": "4w5l6jn4wlk5j6nw4lk56"}```

Добавление пассажира - ```POST /api/v1/passengers```\
request - ```{"Name": "string", "Phone": "string", "Email": "string"}```\
responce - ```{"passangerId": "4w5l6jn4wlk5j6nw4lk56"}```

Создание заказа - ```POST /api/v1/orders```\
request - ```{"OrderType": "string", "Date": "yyyy-mm-dd hh:mm:ss", "Driver": {"driverId": "string"}, "Passenger": {"passengerId": "string"}, "Price": 0, "DriverRate": 0, "PassengerRate": 0}```\
responce - ```{"orderId": "4w5l6jn4wlk5j6nw4lk56"}```

Создание записи в расписании - ```POST /api/v1/time-worksheets```\
request - ```{"Taxi": {"taxiId": "string"}, "Driver": {"driverId": "string"}, "Date": "yyyy-mm-dd", "HourlySalary": 0, "Hours": 0}```\
responce - ```{"timeWorksheetId": "4w5l6jn4wlk5j6nw4lk56"}```

Создание машины - ```POST /api/v1/cars```\
request - ```{"Car number": "string", "Brand": "string", "Model": "string", "Year": "yyyy-mm-dd" ,"CarPark": {"carParkId": "string"}}```\
responce - ```{"carId": "4w5l6jn4wlk5j6nw4lk56"}```

Создание аренды - ```POST /api/v1/car-rents```\
request - ```{"Driver": {"driverId": "string"}, "Car": {"carId": "string"}, "Start date": "yyyy-mm-dd", "End date": "yyyy-mm-dd", "Daily price": "int"}```\
responce - ```{"carRentId": "4w5l6jn4wlk5j6nw4lk56"}```

Получение информации о ИП - ```GET/api/v1/owners/{ownerId}```
responce - ```{"IE": "string", "Name": "string", "Phone": "string"}```

Получение информации о такси-парке - ```GET /api/v1/car-parks/{carParkId}```
responce - ```{"Address": "string", "Postcode": "string", "CarCount": 0}```

Получение информации о водителе - ```GET /api/v1/drivers/{driverId}```
responce - ```{"Name": "string", "DriverLicense": "string", "Passport": "string", "Phone": "string", "Email": "string"}```

Получение информации о пассажире - ```GET /api/v1/passengers/{passengerId}```
responce - ```{"Name": "string", "Phone": "string", "Email": "string"}```

Получение информации о заказе - ```GET /api/v1/orders/{orderId}```
responce - ```{"OrderType": "string", "Date": "yyyy-mm-dd hh:mm:ss", "Driver": {"driverId": "string"}, "Passenger": {"passengerId": "string"}, "Price": 0, "DriverRate": 0, "PassengerRate": 0}```

Получение информации о записи в расписании - ```GET /api/v1/time-worksheets/{timeWorksheetId}```
responce - ```{"Taxi": {"taxiId": "string"}, "Driver": {"driverId": "string"}, "Date": "yyyy-mm-dd", "HourlySalary": 0, "Hours": 0}```

Получение информации об автомобиле - ```GET /api/v1/cars/{carId}```
responce - ```{"CarNumber": "string", "Brand": "string", "Model": "string", "Year": "yyyy", "CarPark": {"carParkId": "string"}}```

Апдейт информации об автомобиле - ```PUT /api/v1/cars/{carId}```
request - ```{"CarNumber": "string", "Brand": "string", "Model": "string", "Year": "yyyy", "CarPark": {"carParkId": "string"}}```
responce - ```{"carId": "4w5l6jn4wlk5j6nw4lk56"}```
