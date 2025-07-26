# Puzzle #86 - Unexpected 404

Carl and Jeff want to know why this API call isn't working in production (Azure Web Apps)

YouTube Video: https://youtu.be/[1uiLkNFRwM4](https://t.co/00u1QXpTln)

Blazor Puzzle Home Page: https://blazorpuzzle.com

## The Challenge

This is a .NET 9 Blazor Web App with Global WebAssembly interactivity.

We are attempting to call an API endpoint passing a login string that includes a backslash (\\).

It only works locally if we escape the backslash, but it does not work in production on Azure.

How can we fix it so that it works both locally and in production?
