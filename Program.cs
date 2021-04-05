using System;
using System.Linq;
using Trabajofinal.Modelo;


namespace Trabajofinal
{
    class Program
    {
        static valid validar = new valid();
        static void Main(string[] args)
        {
            int op;
            string temp;
            bool eVald = false;

            do
            {


                Console.BackgroundColor = ConsoleColor.White;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                Pantalla.pantalla1(118, 23);
                Console.SetCursorPosition(3, 2); Console.WriteLine("App Estudiante");
                Console.SetCursorPosition(5, 4); Console.WriteLine("1. Agregar");
                Console.SetCursorPosition(20, 4); Console.WriteLine("2. Listar");
                Console.SetCursorPosition(35, 4); Console.WriteLine("3. Buscar");
                Console.SetCursorPosition(50, 4); Console.WriteLine("4. Editar");
                Console.SetCursorPosition(65, 4); Console.WriteLine("5. Borrar");
                Console.SetCursorPosition(80, 4); Console.WriteLine("0. Salir");
                Console.SetCursorPosition(55, 17); Console.WriteLine("BIENVENIDOS");
                Console.SetCursorPosition(3, 23); Console.WriteLine("SENA");
                Console.SetCursorPosition(3, 24); Console.WriteLine("centro de mercados logistica y tecnologias de la informacion");

                do
                {
                    Console.SetCursorPosition(70, 2); Console.Write("Escoja una opcion ");
                    temp = Console.ReadLine();
                    if (!validar.vacio(temp))
                        if (validar.tipoNum(temp))
                            eVald = true;
                } while (!eVald);

                op = Convert.ToInt32(temp);

                switch (op)
                {
                    case 1:
                        agregarEs();
                        break;
                    case 2:
                        listarEs();
                        break;
                    case 3:
                        buscarEs();
                        break;
                    case 4:
                        editarEs();
                        break;
                    case 5:
                        borrarEs();
                        break;
                    case 0:
                        endEs();
                        break;
                    default:
                        Console.SetCursorPosition(3, 26); Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.SetCursorPosition(3, 25); Console.WriteLine("Presione cualquier tecla para salir");
                Console.ReadKey();
            } while (op > 0);
        }

        static void agregarEs()
        {
            var db = new tallerfinalContext();
            string cod, nom, corr, n1, n2, n3;
            bool codval = false;
            bool nomval = false;
            bool corrval = false;
            bool n1val = false;
            bool n2val = false;
            bool n3val = false;
            Console.Clear();
            Pantalla.pantalla1(118, 23);
            Console.SetCursorPosition(3, 2); Console.WriteLine("App Estudiante");
            Console.SetCursorPosition(5, 4); Console.WriteLine("1. Agregar");
            Console.SetCursorPosition(20, 4); Console.WriteLine("2. Listar");
            Console.SetCursorPosition(35, 4); Console.WriteLine("3. Buscar");
            Console.SetCursorPosition(50, 4); Console.WriteLine("4. Editar");
            Console.SetCursorPosition(65, 4); Console.WriteLine("5. Borrar");
            Console.SetCursorPosition(80, 4); Console.WriteLine("0. Salir");
            Console.SetCursorPosition(55, 10); Console.Write("AGREGAR ESTUDIANTE");
            do
            {
                Console.SetCursorPosition(55, 13); Console.Write("Digite el codigo: ");
                cod = Console.ReadLine();
                if (!validar.vacio(cod))
                    if (validar.tipoNum(cod))
                        codval = true;
            } while (!codval);
            uint cod1 = Convert.ToUInt32(cod);
            var existe = db.Estudiantes.Find(cod1);
            if (existe == null)
            {
                do
                {
                    Console.SetCursorPosition(55, 14); Console.Write("Digite el nombre : ");
                    nom = Console.ReadLine();
                    if (!validar.vacio(nom))
                        if (validar.tipoText(nom))
                            nomval = true;
                } while (!nomval);

                do
                {
                    Console.SetCursorPosition(55, 15); Console.Write("Digite correo del estudiante: ");
                    corr = Console.ReadLine();
                    if (!validar.vacio(corr))
                        if (validar.tipoMail(corr))
                            corrval = true;
                } while (!corrval);

                do
                {
                    Console.SetCursorPosition(55, 16); Console.Write("Digite la primera nota: ");
                    n1 = Console.ReadLine();
                    if (!validar.vacio(n1))
                        if (validar.tipoNum(n1))
                            n1val = true;
                } while (!n1val);

                do
                {
                    Console.SetCursorPosition(55, 17); Console.Write("Digite la segunda nota: ");
                    n2 = Console.ReadLine();
                    if (!validar.vacio(n2))
                        if (validar.tipoNum(n2))
                            n2val = true;
                } while (!n2val);

                do
                {
                    Console.SetCursorPosition(55, 18); Console.Write("Digite la tercera nota: ");
                    n3 = Console.ReadLine();
                    if (!validar.vacio(n3))
                        if (validar.tipoNum(n3))
                            n3val = true;
                } while (!n3val);


                double nota1 = Double.Parse(n1) * (0.1);
                double nota2 = Double.Parse(n2) * (0.1);
                double nota3 = Double.Parse(n3) * (0.1);
                double nf = (nota1 + nota2 + nota3) / 3;
                double nf1 = (Math.Truncate(nf * 10) / 10);
                Estudiantes myEs = new Estudiantes
                {
                    Codigo = cod1,
                    Nombre = nom,
                    Correo = corr,
                    Nota1 = nota1,
                    Nota2 = nota2,
                    Nota3 = nota3,
                    notafinal= nf1
                };
                db.Estudiantes.Add(myEs);
                db.SaveChanges();
            } else
            {
                Console.SetCursorPosition(55, 25); Console.Write("El codigo ya existe");
                Console.ReadKey();
            }
        }

        static void listarEs()
        {
            var db = new tallerfinalContext();
            int y = 14;
            
            string resl;

            Console.Clear();
            Pantalla.pantalla1(118, 23);
            Console.SetCursorPosition(3, 2); Console.WriteLine("App Estudiante");
            Console.SetCursorPosition(5, 4); Console.WriteLine("1. Agregar");
            Console.SetCursorPosition(20, 4); Console.WriteLine("2. Listar");
            Console.SetCursorPosition(35, 4); Console.WriteLine("3. Buscar");
            Console.SetCursorPosition(50, 4); Console.WriteLine("4. Editar");
            Console.SetCursorPosition(65, 4); Console.WriteLine("5. Borrar");
            Console.SetCursorPosition(80, 4); Console.WriteLine("0. Salir");
            Console.SetCursorPosition(55, 10); Console.Write("LISTAR ESTUDIANTES");
            var listaEs = db.Estudiantes.ToList();

            Console.SetCursorPosition(5, y); Console.Write("Codigo");
            Console.SetCursorPosition(15, y); Console.Write("Nombre");
            Console.SetCursorPosition(35, y); Console.Write("Correo");
            Console.SetCursorPosition(50, y); Console.Write("Primera Nota");
            Console.SetCursorPosition(65, y); Console.Write("Segunda Nota");
            Console.SetCursorPosition(80, y); Console.Write("Tercera Nota");
            Console.SetCursorPosition(95, y); Console.Write("Nota final");
            Console.SetCursorPosition(108, y); Console.Write("Resultado");

            foreach (var myEs in listaEs)
            {
                y++;
                

                if (myEs.notafinal >= 3.5)
                { resl = ("Aprobo"); }
                else resl = ("Reprobo");
                Console.SetCursorPosition(5, y); Console.Write(myEs.Codigo);
                Console.SetCursorPosition(15, y); Console.Write(myEs.Nombre);
                Console.SetCursorPosition(35, y); Console.Write(myEs.Correo);
                Console.SetCursorPosition(50, y); Console.Write(myEs.Nota1);
                Console.SetCursorPosition(65, y); Console.Write(myEs.Nota2);
                Console.SetCursorPosition(80, y); Console.Write(myEs.Nota3);
                Console.SetCursorPosition(95, y); Console.Write(myEs.notafinal.ToString("N2"));
                Console.SetCursorPosition(108, y); Console.Write(resl);
            }
        }
        static void buscarEs()
        {
            var db = new tallerfinalContext();
            string cod;
            bool CodigoValido = false;

            Console.Clear();
            Pantalla.pantalla1(118, 23);
            Console.SetCursorPosition(3, 2); Console.WriteLine("App Estudiante");
            Console.SetCursorPosition(5, 4); Console.WriteLine("1. Agregar");
            Console.SetCursorPosition(20, 4); Console.WriteLine("2. Listar");
            Console.SetCursorPosition(35, 4); Console.WriteLine("3. Buscar");
            Console.SetCursorPosition(50, 4); Console.WriteLine("4. Editar");
            Console.SetCursorPosition(65, 4); Console.WriteLine("5. Borrar");
            Console.SetCursorPosition(80, 4); Console.WriteLine("0. Salir");
            Console.SetCursorPosition(55, 3); Console.WriteLine("Buscar Estudiante");


            do
            {
                Console.SetCursorPosition(10, 8); Console.Write(" Digite Codigo del estudiante que desea buscar: ");
                cod = Console.ReadLine();
                if (!validar.vacio(cod))
                    if (validar.tipoNum(cod))
                        CodigoValido = true;
            } while (!CodigoValido);
            uint cod1 = Convert.ToUInt32(cod);
            var existe = db.Estudiantes.Find(cod1);
            if (existe!=null)
            {
                var myEs = db.Estudiantes.FirstOrDefault(e=> e.Codigo==cod1);
                Console.SetCursorPosition(55, 13); Console.WriteLine($"Codigo: {myEs.Codigo}");
                Console.SetCursorPosition(55, 14); Console.WriteLine($"Nombre: {myEs.Nombre}");
                Console.SetCursorPosition(55, 15); Console.WriteLine($"Correo: {myEs.Correo}");
                Console.SetCursorPosition(55, 16); Console.WriteLine($"Nota 1: {myEs.Nota1}");
                Console.SetCursorPosition(55, 17); Console.WriteLine($"Nota 2: {myEs.Nota2}");
                Console.SetCursorPosition(55, 18); Console.WriteLine($"Nota 3: {myEs.Nota3}");
            }
            else  Console.WriteLine($" El codigo {cod1} NO  existe en el sistema");



        }

        static void editarEs()
        {
            var db = new tallerfinalContext();
            string cod, nom, corr, n1,n2, n3;
            
            bool nomval = false;
            bool corrval = false;
            bool n1val = false;
            bool n2val = false;
            bool n3val = false;
            bool CodigoValido = false;

            Console.Clear();
            Pantalla.pantalla1(118, 23);
            Console.SetCursorPosition(3, 2); Console.WriteLine("App Estudiante");
            Console.SetCursorPosition(5, 4); Console.WriteLine("1. Agregar");
            Console.SetCursorPosition(20, 4); Console.WriteLine("2. Listar");
            Console.SetCursorPosition(35, 4); Console.WriteLine("3. Buscar");
            Console.SetCursorPosition(50, 4); Console.WriteLine("4. Editar");
            Console.SetCursorPosition(65, 4); Console.WriteLine("5. Borrar");
            Console.SetCursorPosition(80, 4); Console.WriteLine("0. Salir");
            Console.SetCursorPosition(55, 3); Console.WriteLine("Editar Estudiante");


            do
            {
                Console.SetCursorPosition(10, 8); Console.Write(" Digite Codigo del estudiante que desea editar: ");
                cod = Console.ReadLine();
                Console.SetCursorPosition(55, 12); Console.Write(" NUEVOS DATOS ");
                
                if (!validar.vacio(cod))
                    if (validar.tipoNum(cod))
                        CodigoValido = true;
            } while (!CodigoValido);
            uint cod1 = Convert.ToUInt32(cod);
            var existe = db.Estudiantes.Find(cod1);
            if (existe != null)
            {
                var myEs = db.Estudiantes.FirstOrDefault(e => e.Codigo == cod1);
                Console.SetCursorPosition(15, 13); Console.WriteLine($"Codigo: {myEs.Codigo}");
                Console.SetCursorPosition(15, 14); Console.WriteLine($"Nombre: {myEs.Nombre}");
                Console.SetCursorPosition(15, 15); Console.WriteLine($"Correo: {myEs.Correo}");
                Console.SetCursorPosition(15, 16); Console.WriteLine($"Nota 1: {myEs.Nota1}");
                Console.SetCursorPosition(15, 17); Console.WriteLine($"Nota 2: {myEs.Nota2}");
                Console.SetCursorPosition(15, 18); Console.WriteLine($"Nota 3: {myEs.Nota3}");

                do
                {
                    Console.SetCursorPosition(55, 14); Console.Write("Digite el nombre : ");
                    nom = Console.ReadLine();
                    if (nom.Equals(""))
                    {
                        nom = myEs.Nombre;
                    }
                        if (validar.tipoText(nom))
                            nomval = true;
                } while (!nomval);

                do
                {
                    Console.SetCursorPosition(55, 15); Console.Write("Digite correo del estudiante: ");
                    corr = Console.ReadLine();
                    if (corr.Equals(""))
                    {
                        corr = myEs.Correo;
                    }
                        if (validar.tipoMail(corr))
                            corrval = true;
                } while (!corrval);

                do
                {
                    Console.SetCursorPosition(55, 16); Console.Write("Digite la primera nota: ");
                    n1 = Console.ReadLine();
                     if (validar.tipoNum(n1))
                            n1val = true;
                } while (!n1val);

                do
                {
                    Console.SetCursorPosition(55, 17); Console.Write("Digite la segunda nota: ");
                    n2 = Console.ReadLine();
                     if (validar.tipoNum(n2))
                            n2val = true;
                } while (!n2val);

                do
                {
                    Console.SetCursorPosition(55, 18); Console.Write("Digite la tercera nota: ");
                    n3 = Console.ReadLine();
                     if (validar.tipoNum(n3))
                            n3val = true;
                } while (!n3val);


                double nota1 = Double.Parse(n1) * (0.1);
                double nota2 = Double.Parse(n2) * (0.1);
                double nota3 = Double.Parse(n3) * (0.1);
                double nf = (nota1 + nota2 + nota3) / 3;
                double nf1 = (Math.Truncate(nf * 10) / 10);
                myEs.Nombre = nom;
                  myEs.Correo = corr;
                  myEs.Nota1 = nota1;
                  myEs.Nota2 = nota2;
                  myEs.Nota3 = nota3;
                  myEs.notafinal = nf1;

                 Console.WriteLine("Los cambios han sido efectuados");
                db.SaveChanges();
            }
            else Console.WriteLine($" El codigo {cod1} NO  existe en el sistema");



        }

        static void borrarEs()
        {
            var db = new tallerfinalContext();
            string cod, comf;
            
            bool CodigoValido = false;
            bool comfVal = false;
            Console.Clear();
            Pantalla.pantalla1(118, 23);
            Console.SetCursorPosition(3, 2); Console.WriteLine("App Estudiante");
            Console.SetCursorPosition(5, 4); Console.WriteLine("1. Agregar");
            Console.SetCursorPosition(20, 4); Console.WriteLine("2. Listar");
            Console.SetCursorPosition(35, 4); Console.WriteLine("3. Buscar");
            Console.SetCursorPosition(50, 4); Console.WriteLine("4. Editar");
            Console.SetCursorPosition(65, 4); Console.WriteLine("5. Borrar");
            Console.SetCursorPosition(80, 4); Console.WriteLine("0. Salir");
            Console.SetCursorPosition(55, 3); Console.WriteLine("Borrar Estudiante");


            do
            {
                Console.SetCursorPosition(10, 8); Console.Write(" Digite Codigo del estudiante que desea borrar: ");
                cod = Console.ReadLine();
                if (!validar.vacio(cod))
                    if (validar.tipoNum(cod))
                        CodigoValido = true;
            } while (!CodigoValido);
            uint cod1 = Convert.ToUInt32(cod);
            var existe = db.Estudiantes.Find(cod1);
            if (existe != null)
            {
                var myEs = db.Estudiantes.FirstOrDefault(e => e.Codigo == cod1);

                Console.SetCursorPosition(15, 13); Console.WriteLine($"Codigo: {myEs.Codigo}");
                Console.SetCursorPosition(15, 14); Console.WriteLine($"Nombre: {myEs.Nombre}");
                Console.SetCursorPosition(15, 15); Console.WriteLine($"Correo: {myEs.Correo}");
                Console.SetCursorPosition(15, 16); Console.WriteLine($"Nota 1: {myEs.Nota1}");
                Console.SetCursorPosition(15, 17); Console.WriteLine($"Nota 2: {myEs.Nota2}");
                Console.SetCursorPosition(15, 18); Console.WriteLine($"Nota 3: {myEs.Nota3}");
                do
                {
                    Console.Write($" Desea borrar los datos de {myEs.Nombre} S/N: ");
                    comf = Console.ReadLine();
                    if (!validar.vacio(comf))
                        if (validar.sino(comf))
                            comfVal = true;
                } while (!comfVal);
                if (comf == "s")
                {
                    db.Estudiantes.Remove(myEs);
                    db.SaveChanges();
                    Console.SetCursorPosition(55, 23); Console.WriteLine(" Se ha eliminado con exito al estudiante");
                }
                else
                 Console.WriteLine("No se ha eliminado al estudiante"); 
            }
            else Console.WriteLine($" El codigo {cod1} NO  existe en el sistema");



        }

        static void endEs()
        {
            Console.Clear();
            Pantalla.pantalla1(118, 23);
            Console.SetCursorPosition(3, 2); Console.WriteLine("App Estudiante");
            Console.SetCursorPosition(5, 4); Console.WriteLine("1. Agregar");
            Console.SetCursorPosition(20, 4); Console.WriteLine("2. Listar");
            Console.SetCursorPosition(35, 4); Console.WriteLine("3. Buscar");
            Console.SetCursorPosition(50, 4); Console.WriteLine("4. Editar");
            Console.SetCursorPosition(65, 4); Console.WriteLine("5. Borrar");
            Console.SetCursorPosition(80, 4); Console.WriteLine("0. Salir");
            Console.SetCursorPosition(53, 15); Console.WriteLine("Gracias por usar nuestro programa");
        }

    }
}

