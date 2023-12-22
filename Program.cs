using System;
using Test.Class;

class Program
{
	/// <summary>
	/// Punto de entrada principal para la aplicación.
	/// </summary>
	/// <param name="args">Argumentos de la línea de comandos.</param>
	static void Main(string[] args)
	{
		Records records = new Records();

		do
		{
			Console.Clear();
			Console.WriteLine("Menú Principal");
			Console.WriteLine("1. Agregar gasto");
			Console.WriteLine("2. Ver gastos");
			Console.WriteLine("3. Actualizar gasto");
			Console.WriteLine("4. Eliminar gasto");
			Console.WriteLine("5. Salir");

			Console.Write("Selecciona una opción: ");
			var input = Console.ReadLine();

			if (int.TryParse(input, out int option))
			{
				switch (option)
				{
					case 1:
						AddExpense(records);
						break;

					case 2:
						ViewExpenses(records);
						break;

					case 3:
						UpdateExpense(records);
						break;

					case 4:
						DeleteExpense(records);
						break;

					case 5:
						Environment.Exit(0);
						break;

					default:
						Console.WriteLine("Opción no válida. Por favor, selecciona una opción válida.");
						break;
				}
			}
			else
			{
				Console.WriteLine("Entrada no válida. Por favor, ingresa un número.");
			}

			Console.WriteLine("Presiona cualquier tecla para continuar...");
			Console.ReadKey();

		} while (true);
	}

	/// <summary>
	/// Agrega un nuevo gasto a la lista de facturas.
	/// </summary>
	/// <param name="records">Instancia de la clase Records.</param>
	static void AddExpense(Records records)
	{
		Console.WriteLine(
			"\nEjemplo:" +
			"\n1. Descripción: Gastos de la universidad" +
			"\n2. Categoria: Escuela" +
			"\n3. Cantidad: 1000" +
			"\n4. Método de pago: Efectivo o Tarjeta"
			);
		Bills newBill = new Bills
		{
			Date = DateTime.Now,
			Description = Console.ReadLine() ?? "Descripción",
			Category = Console.ReadLine() ?? "Escuela",
			Amount = Convert.ToDecimal(Console.ReadLine()),
			Type = Console.ReadLine() ?? "Efectivo"
		};
		records.Create(newBill);
		Console.WriteLine("Gasto agregado exitosamente.");
	}

	/// <summary>
	/// Muestra todos los gastos en la lista de facturas.
	/// </summary>
	/// <param name="records">Instancia de la clase Records.</param>
	static void ViewExpenses(Records records)
	{
		var allBills = records.Read();
		foreach (var entry in allBills)
		{
			var bill = entry.Value;
			var billId = entry.Key;

			Console.WriteLine($"ID: {billId}, Fecha: {bill.Date}, Descripción: {bill.Description}, Categoría: {bill.Category}, Monto: {bill.Amount}, Tipo de Pago: {bill.Type}");
		}
	}


	/// <summary>
	/// Actualiza la información de un gasto en la lista de facturas.
	/// </summary>
	/// <param name="records">Instancia de la clase Records.</param>
	static void UpdateExpense(Records records)
	{
		Console.Write("Ingrese el ID del gasto a actualizar: ");
		if (int.TryParse(Console.ReadLine(), out int idToUpdate))
		{
			if (records.Read().ContainsKey(idToUpdate))
			{
				Console.WriteLine(
					"\nEjemplo:" +
					"\n1. Descripción: Gastos de la universidad" +
					"\n2. Categoria: Escuela" +
					"\n3. Cantidad: 1000" +
					"\n4. Método de pago: Efectivo o Tarjeta"
					);
				Bills updatedBill = new Bills
				{
					Date = DateTime.Now,
					Description = Console.ReadLine() ?? "Descripción",
					Category = Console.ReadLine() ?? "Escuela",
					Amount = Convert.ToDecimal(Console.ReadLine()),
					Type = Console.ReadLine() ?? "Efectivo"
				};
				records.Update(idToUpdate, updatedBill);
				Console.WriteLine("Gasto actualizado exitosamente.");
			}
			else
			{
				Console.WriteLine("El ID proporcionado no existe en la lista de gastos.");
			}
		}
		else
		{
			Console.WriteLine("Entrada no válida. Por favor, ingresa un número.");
		}
	}

	/// <summary>
	/// Elimina un gasto de la lista de facturas.
	/// </summary>
	/// <param name="records">Instancia de la clase Records.</param>
	static void DeleteExpense(Records records)
	{
		Console.Write("Ingrese el ID del gasto a eliminar: ");
		if (int.TryParse(Console.ReadLine(), out int idToDelete))
		{
			records.Delete(idToDelete);
			Console.WriteLine("Gasto eliminado exitosamente.");
		}
		else
		{
			Console.WriteLine("Entrada no válida. Por favor, ingresa un número.");
		}
	}
}
