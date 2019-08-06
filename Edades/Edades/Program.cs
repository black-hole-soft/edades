/*
 * Creado por SharpDevelop.
 * Usuario: ggonzalez
 * Fecha: 08/10/2008
 * Hora: 10:12 a.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;

namespace Edades
{
	class Program
	{
		internal enum mienu{
			Infante,
			Niño,
			Adolescente,
			Adulto,
			Anciano,
			Deafult
		}
		internal mienu Pedad(int edad){
			double[] v=new double[5];
			v[0]=Membresias.trapecioIzq(edad,3,6);
			v[1]=Membresias.trapecio(edad,4,6,9,14);
			v[2]=Membresias.trapecio(edad,10,15,18,23);
			v[3]=Membresias.trapecio(edad,19,25,50,60);
			v[4]=Membresias.trapecioDer(edad,55,65);
			double may=mayor(v);
			if(may==v[0])
				return mienu.Infante;
			if(may==v[1])
				return mienu.Niño;
			if(may==v[2])
				return mienu.Adolescente;
			if(may==v[3])
				return mienu.Adulto;
			if(may==v[4])
				return mienu.Anciano;
			return mienu.Deafult; 
		}
		public double mayor(double[] edad){
			double may=edad[0];
			for(int i=1;i<edad.Length;i++)
				if(edad[i]>may)
					may=edad[i];
			return may;
		}
		public static void Main(string[] args)
		{
			Program pro=new Program();
			String edades = File.ReadAllText("edades.txt");
			String[] fuente = edades.Split('\n');
			String[] persona;
			int i;
			Console.WriteLine(" Edades:");
			for(i=0;i<fuente.Length;i++){
				persona=fuente[i].Split(',');
				Console.Write("{0},",persona[0]);
				Console.WriteLine(pro.Pedad(int.Parse(persona[1])));
			}
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}