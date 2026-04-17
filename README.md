# 👕 Shirt Management System (ASP.NET Core)

## 📌 Project Overview

This is a full-stack application built using **ASP.NET Core Web API and MVC**.
The system allows users to manage shirts with complete CRUD functionality and secure API access.

---

## 🚀 Features

* ✅ Create, Read, Update, Delete Shirts
* ✅ Form validation (Client & Server side)
* ✅ API consumption using MVC
* ✅ Error handling with custom exception handling
* ✅ API security using Client Credentials (clientId & clientSecret)
* ✅ Token-based authentication (basic implementation)
* ✅ Clean UI with Bootstrap

---

## 🧠 Technologies Used

* ASP.NET Core Web API
* ASP.NET Core MVC
* Entity Framework Core
* SQL Server (LocalDB)
* HttpClientFactory
* Dependency Injection
* Action Filters & Exception Filters

---

## 🔐 Security Implementation

* Implemented **Client Credential Authentication**
* Created an authentication endpoint (`/api/authority/auth`)
* Validates `clientId` and `clientSecret`
* Returns access token with expiration time
* Handles unauthorized access with proper HTTP status codes

---

## 🏗️ Architecture

MVC App → WebApiExecutor → Web API → EF Core → SQL Database

---

## 🔥 Key Concepts Implemented

* RESTful API design
* Dependency Injection (DI)
* API consumption using HttpClient
* Centralized error handling using custom exceptions
* Model validation with DataAnnotations
* Action Filters & Exception Filters
* Secure API endpoints

---

## 🧪 How to Run

1. Clone the repository
2. Run Web API project
3. Run MVC project
4. Navigate to `/Shirts`

---

## 👩‍💻 Author

Kasuni Waththage

---

## 💡 Note

This project was built to strengthen my understanding of real-world full-stack development using .NET technologies.
