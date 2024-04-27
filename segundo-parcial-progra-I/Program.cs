using segundo_parcial_progra_I;
using segundo_parcial_progra_I.clases;
using segundo_parcial_progra_I.herencia;

using System;
using System.Diagnostics;


Policia chonte = new Policia();
chonte.nombre = "Pedrito";
chonte.edad = "12";
chonte.sexo = "M";
chonte.rango = "Oficial";
Console.WriteLine($"Nombre: {chonte.nombre}, edad: {chonte.edad}, sexo: {chonte.sexo}, rango: {chonte.rango} ");
chonte.saludar();

chonte.accionPrincipal();

//Animales
Ave pajarito  = new Ave();
pajarito.Nombre = "Pedrito";
pajarito.volar();

//delegados
static void TestMethod()
{
    delegates ejemplo1 = new delegates();
    ejemplo1.ejemploDelegado();
}

TestMethod();

delegates mensajes = new delegates();
DelegadoString  mensaje = mensajes.ImprimirMensaje2;
mensaje(" este es el delegado 2");

delegates sumar  = new delegates();
DelegadoInt suma = sumar.Sumar;
suma(3, 4);


delegates saludar = new delegates();
DecirHola saludoConNombre = saludar.SaludarPorNombre;
saludoConNombre("Pedrito");



//eventos

SuscriptorCalculadora calculadora = new SuscriptorCalculadora(3, 5);
calculadora.OperacionSuma();
calculadora.OperacionResta();

////indexer
int n = 0;
TiendaAutosInd tiendita = new TiendaAutosInd();

//obtener un auto 
AutoIndexer auto = tiendita[2];
auto.MostrarInformacionAuto();

//registrar
AutoIndexer OtroAuto = new AutoIndexer("Honda", 3113);
tiendita[3] = OtroAuto;

for (n = 0; n < 5; n++)
{
    tiendita[n].MostrarInformacionAuto();
}