// See https://aka.ms/new-console-template for more information
using EntityRepoBuilder.Entities;
using EntityRepoBuilder.QueryBuilder;
using EntityRepoBuilder.Scanner;

Console.WriteLine("Hello, World!\n I'm here to build some queries for you!\n\n");

var target = EntityScanner.Scan(new RootEntity());
var builder = new QueryBuilder(target);

Console.WriteLine(builder.GenerateSelect());
Console.WriteLine("\n\n\n\n");
Console.WriteLine(builder.GenerateUpdate());
Console.WriteLine("\n\n\n\n");
Console.WriteLine(builder.GenerateInsert());


var deeb = "";