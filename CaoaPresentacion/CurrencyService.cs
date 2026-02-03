using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

 namespace TuNamespace  // Cambia esto por el namespace de tu proyecto
{
    public class CurrencyService : IDisposable
    {
        private readonly HttpClient _httpClient;
        private bool _disposed = false;

        public CurrencyService()
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(20)
            };

            // Agregar headers para evitar bloqueos
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        // Método principal para obtener tasa USD → NIO
        public async Task<decimal> GetUsdToNioRateAsync()
        {
            try
            {
                string url = "https://api.frankfurter.app/latest?from=USD&to=NIO";

                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error en la API: {(int)response.StatusCode} - {response.ReasonPhrase}");
                }

                string json = await response.Content.ReadAsStringAsync();

                // Parsear el JSON dinámicamente
                dynamic data = JsonConvert.DeserializeObject(json);

                if (data == null || data.rates == null)
                {
                    throw new Exception("La API devolvió una respuesta inválida");
                }

                // Obtener la tasa NIO
                decimal rate = data.rates.NIO;
                return rate;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión: {ex.Message}");
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error al procesar los datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        // Método alternativo: Obtener cualquier tasa
        public async Task<decimal> GetExchangeRateAsync(string fromCurrency, string toCurrency)
        {
            try
            {
                string url = $"https://api.frankfurter.app/latest?from={fromCurrency}&to={toCurrency}";
                string json = await _httpClient.GetStringAsync(url);

                dynamic data = JsonConvert.DeserializeObject(json);
                return data.rates[toCurrency];
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener tasa {fromCurrency}→{toCurrency}: {ex.Message}");
            }
        }

        // Método para verificar si la API está disponible
        public async Task<bool> IsApiAvailableAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://api.frankfurter.app/latest");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // Implementar IDisposable para liberar recursos
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient?.Dispose();
                }
                _disposed = true;
            }
        }
    }
}