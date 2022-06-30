# ChatRepo
# steps for set up installation
# Repository url to get code https://github.com/fiazkhanniazi/ChatRepo
# Install ERLANG server from  – https://www.erlang.org/downloads 
# We will be installing the RabbitMQ Server and a service within our Windows machine
# https://www.rabbitmq.com/install-windows.html. I used the official installer. Make sure that you are an Admin
# Commands for enabling dashboard  and starting the window service
# cd C:\Program Files\RabbitMQ Server\rabbitmq_server-3.8.7\sbin
# rabbitmq-plugins enable rabbitmq_management
# net stop RabbitMQ
# net start RabbitMQ
# url to check RabbitMQ is running or not http://localhost:15672/
# You should have visual studio 2022 to for loading the solution
# Go to Tools options then select Nuget Manager Console 
# Select Persistent project and run command to update database  -- Update-Database
# open a solution from local mapped repository in a visual studio 2022 
# Right click on solution then go to properties
# Slect the radio button multiple startup project
# On Action drop down slect start in front of ChatApp,StockBot and Web
# Then click on start in visual studio then app will be in running state and you can register and login from browser
