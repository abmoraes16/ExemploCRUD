using System;
using System.Collections.Generic;

namespace ExemploCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            BancoDados banco = new BancoDados();
            Categoria categoria = new Categoria();

            int opcao = 0;
            
            do{

            Console.WriteLine("\n\nTabela Categoria\n");
            Console.WriteLine("1- Cadastrar\n2- Atualizar\n3- Consultar\n4- Excluir\n5- Sair");
            
            opcao = int.Parse(Console.ReadLine());
            
            switch(opcao){
                case 1: Console.Write("Titulo: ");
                        categoria.Titulo = Console.ReadLine();
                        if(banco.Adicionar(categoria))
                            Console.WriteLine("Registro cadastrado com sucesso!");
                            break;
                case 2: Console.Write("ID: ");
                        categoria.IdCategoria = int.Parse(Console.ReadLine());
                        
                        Console.Write("Titulo a ser atualizado: ");
                        categoria.Titulo = Console.ReadLine();

                        if(banco.Atualizar(categoria))
                            Console.WriteLine("Registro atualizado com sucesso!");
                            break;
                case 3: List<Categoria> lista = new List<Categoria>();
                        Console.WriteLine("Consultar Categoria\n\n1- Pelo Id\n2- Pelo Nome");
                            opcao = int.Parse(Console.ReadLine());
                            
                            if(opcao==1){
                                Console.Write("Id: ");
                                int Id = Convert.ToInt32(Console.ReadLine());
                                
                                lista = banco.ListarCategorias(Id);
                                
                                Console.WriteLine("\n\nID TITULO");
                                foreach(Categoria item in lista){
                                    Console.WriteLine(item.IdCategoria+" "+item.Titulo);
                                }
                            }

                            if(opcao==2){
                                Console.Write("Titulo: ");
                                string Titulo = Console.ReadLine();
                                
                                lista = banco.ListarCategorias(Titulo);
                                
                                Console.WriteLine("\n\nID TITULO");
                                foreach(Categoria item in lista){
                                    Console.WriteLine(item.IdCategoria+" "+item.Titulo);
                                }
                            }
                        
                        break;
                case 4: Console.Write("Id: ");
                        categoria.IdCategoria = int.Parse(Console.ReadLine());
                        if(banco.Apagar(categoria)){
                            Console.WriteLine("Registro deletado com sucesso!");
                        }
                        break;
                case 5: Environment.Exit(1);
                        break;
            }
            }
            while(opcao!=5);
            
        }
    }
}
