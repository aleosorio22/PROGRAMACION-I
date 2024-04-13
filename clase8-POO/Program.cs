using clase8_POO.Clases;

Carro carrito = new Carro("toyota", 2021);
Carro car2 = new Carro("Nissan",2023 );


carrito.Color = "blanco";
carrito.Owner = "Jorge";

Console.WriteLine($"Marca: {carrito.Marca}, modelo: {carrito.Modelo}");
Console.WriteLine($"Marca carro 2: {car2.Marca}, modelo: {car2.Modelo}");

if (car2.Acelerar() == 0)
{
    Console.WriteLine("El carro esta apagado");
}
else
{
    Console.WriteLine(car2.Acelerar() + "/kph");
    Console.WriteLine(car2.Acelerar() + "/kph");
}

Console.WriteLine($"Encendiendo el carro...");
car2.EncenderCarro();
Console.WriteLine(car2.Acelerar() + "/kph");
Console.WriteLine(car2.Acelerar() + "/kph");
Console.WriteLine(car2.Acelerar() + "/kph");

Console.WriteLine($"Apagando el carro... {car2.ApagarCarro}");

