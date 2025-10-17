# ApiMusicas — Mini projeto

Console app em C# que baixa uma lista de músicas (JSON) e fornece filtros/visões via menu interativo.

## Estrutura principal
- [Program.cs](Program.cs) — fluxo principal, menu e download do JSON.
- [Models/Musica.cs](Models/Musica.cs) — modelo que converte o campo inteiro `key` em nota (string) via [`ApiMusicas.Models.Musica`](Models/Musica.cs).
- [Filters/Filter.cs](Filters/Filter.cs) — filtros: [`ApiMusicas.Filters.Filter.GenerosFiltro`](Filters/Filter.cs), [`ApiMusicas.Filters.Filter.ArtistasPorGenero`](Filters/Filter.cs), [`ApiMusicas.Filters.Filter.MusicasPorArtista`](Filters/Filter.cs).
- [Filters/Order.cs](Filters/Order.cs) — ordenações/visualizações auxiliares (ex.: [`ApiMusicas.Filters.Order.ArtistasEmOrdem`](Filters/Order.cs)).
- [ApiMusicas.csproj](ApiMusicas.csproj) — projeto .NET.

## Pré-requisitos
- .NET 7.0+ ou .NET 8.0+ instalado.
- Conexão com a internet (o app baixa o JSON em tempo de execução).

## Como executar
1. Pelo terminal na pasta do projeto:
   ```sh
   dotnet build
   dotnet run