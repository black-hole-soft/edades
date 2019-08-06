using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace Practica_1
{
    class Codigo
    {
        public int   dir;
        public int   ins;
        public int   mem;
        public bool  exe;
        public Codigo() {
            dir = 0;
            ins = 0;
            mem = 0;
            exe = false;
        }
    }
    class Program
    {
        public static int ac, pc, cods, mems;
        public static bool error;
        public static Codigo[] codi;
        public static String path2;
        static void Main(string[] args)
        {
            error = false;
            codi = new Codigo[20];
            String path, cadena, archivo;
            String[] dircod;
            int dir, ins, mem, aux, i,cont=0;
            ac = 0;
            pc = 0;

            Console.Write("Archivo: ");
            archivo = Console.ReadLine();
            path = "C:\\" + archivo + ".txt";
            path2 = "C:\\" + archivo + "AUX.txt";
            cadena = File.ReadAllText(path);
            File.WriteAllText(path2,"0");
            String[] fuente = cadena.Split('\n');
            
            if (fuente[0].Split().Length != 2)
            {
                Console.WriteLine("El primer parametro debe ser # de instrucciones");
                error=true;
            }
            else
            {
                if (fuente[1].Split().Length != 2)
                {
                    Console.WriteLine("El segundo parametro debe ser # de memorias");
                    error = true;
                }
                else
                {
                    if (numero(fuente[0]))
                    {
                        cods = int.Parse(fuente[0]);
                        if (numero(fuente[1]))
                        {
                            mems = int.Parse(fuente[1]);
                            if (cods + mems > 20 || cods + mems <1)
                            {
                                Console.WriteLine("La suma de instrucciones y memorias deber ser de 1 a 20");
                                error = true;
                            }
                            else
                            {
                                for (i = 2; i < fuente.Length; i++)
                                {
                                    dircod = fuente[i].Split();
                                    if (dircod.Length == 3)
                                    {
                                        if (numero(dircod[0]))
                                        {
                                            dir = int.Parse(dircod[0]);
                                            if (numero(dircod[1]))
                                            {
                                                if (dir > 999 || dir < 0)
                                                {
                                                    Console.WriteLine("La direccion debe estar entre 0 y 999");
                                                    error = true;
                                                }
                                                else
                                                {
                                                    aux = int.Parse(dircod[1]);
                                                    if (aux > 8999 || aux < 0)
                                                    {
                                                        Console.WriteLine("La direccion debe estar entre 0 y 8999");
                                                        error = true;
                                                    }
                                                    else
                                                    {
                                                        ins = aux / 1000;
                                                        mem = aux % 1000;
                                                        if (busca(dir, cont))
                                                        {
                                                            Console.WriteLine("No se pueden repetir las direcciones");
                                                            error = true;
                                                        }
                                                        else
                                                        {
                                                            agregar(cont, dir, ins, mem);
                                                            imprime(codi[cont].dir);
                                                            Console.Write(codi[cont].ins);
                                                            imprime(codi[cont].mem);
                                                            Console.WriteLine("");
                                                            cont++;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (dircod[0] != "")
                                        {
                                            Console.WriteLine("Deben ser 2 parametros");
                                            error = true;
                                        }
                                    }
                                }
                                if (!error)
                                {
                                    if (consecutivas())
                                    {
                                        if(cods+mems!=cont)
                                        {
                                            Console.WriteLine("El # de direcciones no coincide con los parametros iniciales");
                                            error = true;
                                        }
                                        else
                                            ejecutar();
                                    }
                                    else
                                    {
                                        Console.WriteLine("las direcciones de instruccion deben ser consecutivas");
                                        error = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if(error)
                Console.WriteLine("Ocurrieron errores al interpretar");
            Console.ReadLine();
        }
        static void ejecutar() 
        {
            int i = 0,dirini = codi[0].dir,memory;
            pc = dirini;
            String cad;
            Console.Write("pc");
            Console.Write("\t");
            Console.Write("ir");
            Console.Write("\t");
            Console.WriteLine("ac");
            while (i < cods && !codi[i].exe)
            {
                codi[i].exe = true;
                imprime(pc);
                Console.Write("\t");
                Console.Write(codi[i].ins);
                imprime(codi[i].mem);
                Console.Write("\t");
                switch(codi[i].ins)
                {
                    case 0: pc = codi[i].mem; i = codi[i].mem - dirini;
                        break;
                    case 1: 
                        memory=buscaM(codi[i].mem);
                        if (memory > -1)
                            ac = codi[memory].mem;
                        else
                        {
                            Console.WriteLine("Esa direccion de memoria no existe");
                            error = true;
                        }
                        i++;
                        pc++;
                        break;
                    case 2:
                        memory = buscaM(codi[i].mem);
                        if (memory > -1)
                            codi[memory].mem = ac;
                        else
                        {
                            Console.WriteLine("Esa direccion de memoria no existe");
                            error = true;
                        }
                        i++; 
                        pc++;
                        break;
                    case 3:
                        memory = buscaM(codi[i].mem);
                        if (memory > -1)
                            ac = ac+codi[memory].mem;
                        else
                        {
                            Console.WriteLine("Esa direccion de memoria no existe");
                            error = true;
                        }
                        i++; 
                        pc++;
                        break;
                    case 4:
                        memory = buscaM(codi[i].mem);
                        if (memory > -1)
                            ac = ac - codi[memory].mem;
                        else
                        {
                            Console.WriteLine("Esa direccion de memoria no existe");
                            error = true;
                        }
                        i++; 
                        pc++;
                        break;
                    case 5:
                        memory = buscaM(codi[i].mem);
                        if (memory > -1)
                            ac = ac * codi[memory].mem;
                        else
                        {
                            Console.WriteLine("Esa direccion de memoria no existe");
                            error = true;
                        }
                        i++; 
                        pc++;
                        break;
                    case 6:
                        memory = buscaM(codi[i].mem);
                        if (memory > -1)
                        {
                            if(codi[memory].mem==0)
                            {
                                Console.WriteLine("Se evito una divicion por cero");
                                error = true;
                            }
                            else
                                ac = ac / codi[memory].mem;
                        }
                        else
                        {
                            Console.WriteLine("Esa direccion de memoria no existe");
                            error = true;
                        }
                        i++; 
                        pc++;
                        break;
                    case 7:
                        cad = File.ReadAllText(path2);
                        ac = ac + int.Parse(cad);
                        i++; 
                        pc++;
                        break;
                    case 8:
                        cad = Convert.ToString(ac);
                        File.WriteAllText(path2,cad);
                        i++; 
                        pc++;
                        break;
                }
                if (ac < 1000)
                    Console.Write("0");
                imprime(ac);
                Console.WriteLine("");
            }
            Console.WriteLine("Memorias");
            for (i = cods; i < cods + mems; i++)
            {
                imprime(codi[i].dir);
                Console.Write("\t");
                Console.Write(codi[i].ins);
                imprime(codi[i].mem);
                Console.WriteLine("");
            }
        }
        static void imprime(int num) 
        {
            if(num < 100)
                Console.Write("0");
            if (num < 10)
                Console.Write("0");
            Console.Write(num);
        }
        static void agregar(int n,int dir,int ins,int mem)
        {
            codi[n] = new Codigo();
            codi[n].dir = dir;
            codi[n].ins = ins;
            codi[n].mem = mem;
        }
        static bool busca(int dir,int n) 
        {
            for (int i = 0; i < n;i++ )
                if (codi[i].dir == dir)
                    return true;
            return false;
        }
        static int buscaM(int mem)
        {
            for (int i = 0; i < cods+mems; i++)
                if (codi[i].dir == mem)
                    return i;
            return -1;
        }
        static bool consecutivas() 
        {
            int dirini = codi[0].dir;
            if(cods>1)
                for (int i=1; i < cods; i++)
                    if (dirini + i != codi[i].dir)
                        return false;
            return true;
        }
        static bool numero(String cad) 
        {
            for (int i = 0; i < cad.Length-1; i++)
            {
                if (cad[i] < '0' || cad[i] > '9')
                {
                    Console.WriteLine("Solo se admiten numeros");
                    return false;
                }
            }
            return true;
        }
    }
}
