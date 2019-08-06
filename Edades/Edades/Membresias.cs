/*
 * Creado con SharpDevelop 2
 * Desarrollador: Luis Casillas
 * Fecha: 09/06/2007
 * Hora: 08:33 a.m.
 * 
 * DCC/CUCEI/UdeG.
 */

using System;

namespace Edades{	
	public class Membresias{
		public static double triangular(double x,double a,double b,double c){
			if (x<a||x>c) return 0.0;
			if (a<=x&&x<=b) return (x-a)/(b-a);
			if (b<=x&&x<=c) return (c-x)/(c-b);
			return -1;
 		}
 		public static double trapecio(double x,double a,double b,double c,double d){
			if (x<a||x>d) return 0.0;
			if (b<=x&&x<=c) return 1.0;
			if (a<=x&&x<=b) return (x-a)/(b-a);
			if (c<=x&&x<=d) return (d-x)/(d-c);
			return -1;
 		}
 		public static double trapecioIzq(double x,double a,double b){
			if (x>b) return 0.0;
			if (x<a) return 1.0;
			if (a<=x&&x<=b) return (b-x)/(b-a);
			return -1;
 		}
 		public static double trapecioDer(double x,double a,double b){
			if (x>b) return 1.0;
			if (x<a) return 0.0;
			if (a<=x&&x<=b) return (x-a)/(b-a);
			return -1;
 		}
 		public static double curva_S(double x,double a,double b){
			if (x>b) return 1.0;
			if (x<a) return 0.0;
			if (a<=x&&x<=b) return 0.5*(1+Math.Cos(((x-b)/(b-a))*Math.PI));
			return -1;
 		}
 		public static double curva_Z(double x,double a,double b){
			if (x>b) return 0.0;
			if (x<a) return 1.0;
			if (a<=x&&x<=b) return 0.5*(1+Math.Cos(((x-a)/(b-a))*Math.PI));
			return -1;
 		}
 		private static double min(double a,double b){
			return a<b?a:b;
 		}
 		public static double curva_Pi(double x,double a,double b,double c,double d){
			return min(curva_S(x,a,b),curva_Z(x,c,d));
 		}
	}
}
