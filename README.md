# Distributed Order Processing API

A simple ASP.NET Core Web API that mimics a basic distributed order processing system with in-memory messaging.

---

##  Project Setup Instructions

###  Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download)
- Optional: [SQLite Browser](https://sqlitebrowser.org/) 
- Swagger , Postman (for testing)

### Setup Steps

1. **Clone the Repository**
   git clone https://github.com/yourusername/order-processing-api.git
   cd order-processing-api

2. **Restore Dependencies**
   dotnet restore

3. **Run Database Migrations**
   dotnet ef database update


##  API Endpoints

### POST `/order`
Create a new order.

#### Request Body:
```json
{
  "product": "Keyboard",
  "quantity": 2,
  "orderDate": "2025-05-12T10:45:00Z"
}
```
 
 #### Response Body :
 ```json
{
  "id": 2,
  "product": "Keyboard",
  "quantity": 2,
  "orderDate": "2025-05-12T10:45:00Z"
} 
```

### GET '/order/{id}'
Get order details after passing order-id
```
Example Request:
GET https://localhost:5001/order/1

Response (200 OK):
{
  "id": 2,
  "product": "Keyboard",
  "quantity": 2,
  "orderDate": "2025-05-12T10:45:00Z"
}
```

##  What Each Module Does

### `/Controllers/OrdersController.cs`
- **Handles the HTTP** endpoints for creating and fetching orders.
- **Logs** actions and publishes order events to the queue.

### `/Data/OrderContext.cs`
- **Entity Framework** `DbContext` class that manages the SQLite database connection and schema.
- Defines the **`Orders`** table structure and manages database interactions.

### `/Models/Order.cs`
- Represents the **Order** entity, containing fields like `Id`, `CustomerName`, `Product`, `Quantity`, etc.
- This model is used to **store** and **retrieve** data from the database.

### `/Queue/IMessageQueue.cs` & `/Queue/MessageQueue.cs`
- Defines and implements a **simple in-memory message queue** using `Channel<string>`.
- Simulates event publishing  for **order confirmation messages**.

## [Order API Screenshot]
please check
Post : 
![image_alt](https://github.com/12chinmayjain/OrderService/blob/a03dfd916dce1ded3204c1dfce4aa078c6b877e4/Images/post.PNG)

![image_alt](https://github.com/12chinmayjain/OrderService/blob/a03dfd916dce1ded3204c1dfce4aa078c6b877e4/Images/post1.PNG)

Get  :
![image_alt](https://github.com/12chinmayjain/OrderService/blob/69a99152c258246cc654c8ad66801216c0881948/Images/Get1.PNG)

MessageQueue :
![image_alt](https://github.com/12chinmayjain/OrderService/blob/a03dfd916dce1ded3204c1dfce4aa078c6b877e4/Images/MQ1.PNG)

DataBase:
![image_alt](https://github.com/12chinmayjain/OrderService/blob/a03dfd916dce1ded3204c1dfce4aa078c6b877e4/Images/db4.PNG)