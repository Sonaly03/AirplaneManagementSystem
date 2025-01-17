using System;
using System.Collections.Generic;
using System.IO;
using AirplaneManagementSystem.Models;
using System.Text.Json;

namespace AirplaneManagementSystem.Services
{
    public class FlightServices
    {

        private List<Flight> Flights;
        private Dictionary<string, Order> Orders;
        

        
        public FlightServices()
        {
            Flights = new List<Flight>();
           
            Orders =new  Dictionary<string, Order>();
        }


        public static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };


        public void LoadFlightAndOrders(string flightSchedulePath, string orderSchedulePath)
        {
            try
            {

                var flightJsonContent = File.ReadAllText(flightSchedulePath);


                var flightsWrapper = JsonSerializer.Deserialize<FlightsWrapper>(flightJsonContent, options);

                if (flightsWrapper != null)
                {
                    int currentDay = 1;
                    foreach (var flight in flightsWrapper.Flights)
                    {
                        flight.Day = currentDay;
                        Flights.Add(flight);

                        if (flight.FlightNumber == 3)
                        {
                            currentDay++;
                        }
                    }
                }
                Console.WriteLine($"Loaded {Flights.Count} flights");

                var orderJsonContent = File.ReadAllText(orderSchedulePath);
                Orders = JsonSerializer.Deserialize<Dictionary<string, Order>>(orderJsonContent, options);
                Console.WriteLine($"Loaded {Orders.Count} orders");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading flight schedule and orders: {ex.Message}");
            }
        }
        public void AssignOrdersToFlights()
        {

            foreach (var order in Orders)
            {

                bool assignedOrders = false;

                //assign order based on the capacity and the destination
                foreach (var flight in Flights)
                {
                    if (flight.Orders.Count < flight.Capacity && flight.ArrivalCity == order.Value.Destination)
                    {
                        flight.Orders.Add(order.Key, order.Value);

                        assignedOrders = true;
                        break;
                    }
                }

                if (!assignedOrders)
                {
                    Console.WriteLine($"Order: {order.Key}, flightNumber: not scheduled");
                    
                }

            }
            foreach (var flight in Flights)
            {
                foreach (var orderList in flight.Orders)
                {
                    Console.WriteLine($"Order: {orderList.Key}, flightNumber: {flight.FlightNumber}, departure: {flight.DepartureCity}, arrival: {flight.ArrivalCity}, day: {flight.Day}");
                  
                }
            }
        }

        public void DisplayFlightSchedule()
        {
            foreach (var flight in Flights)
            {
                Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.DepartureCity}, arrival: {flight.ArrivalCity}, day: {flight.Day}");
                Console.ReadLine();
            }
        }
    }
}

