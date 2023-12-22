namespace Test.Class
{
	/// <summary>
	/// Clase que gestiona un registro de facturas.
	/// </summary>
	public class Records
	{
		private Dictionary<int, Bills> List;

		/// <summary>
		/// Obtiene la longitud actual de la lista de facturas.
		/// </summary>
		public int GetLengthList
		{
			get { return List.Count; }
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase Records.
		/// </summary>
		public Records()
		{
			List = new Dictionary<int, Bills>();
		}

		/// <summary>
		/// Agrega una factura a la lista.
		/// </summary>
		/// <param name="bills">La factura a agregar.</param>
		public void Create(Bills bills)
		{
			List.TryAdd(GetLengthList, bills);
		}

		/// <summary>
		/// Obtiene la lista completa de facturas.
		/// </summary>
		/// <returns>La lista de facturas.</returns>
		public Dictionary<int, Bills> Read()
		{
			return List;
		}

		/// <summary>
		/// Actualiza una factura en la lista.
		/// </summary>
		/// <param name="id">Identificador de la factura a actualizar.</param>
		/// <param name="bills">La nueva información de la factura.</param>
		public void Update(int id, Bills bills)
		{
			if (List.ContainsKey(id))
			{
				List[id] = bills;
			}
			else
			{
				throw new ArgumentException("La factura con el ID proporcionado no existe en la lista.");
			}
		}

		/// <summary>
		/// Elimina una factura de la lista.
		/// </summary>
		/// <param name="id">Identificador de la factura a eliminar.</param>
		public void Delete(int id)
		{
			List.Remove(id);
		}
	}
}
