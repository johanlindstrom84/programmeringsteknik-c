using NGeoNames;
using NGeoNames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace geocode
{
    class Program
    {
        const string _resoucePatch = ".\\Resources\\SE.txt";
        
        static readonly IEnumerable<ExtendedGeoName> _locationNames;
        static readonly ReverseGeoCode<ExtendedGeoName> _reverseGeoCodingService;

        static readonly (double lat, double lng)_gavlePosistion;
        static readonly (double lat, double lng) _uppsalaPosistion;
        static Program()
        {
            _locationNames = GeoFileReader.ReadExtendedGeoNames(".\\Resources\\SE.txt");
            _reverseGeoCodingService = new ReverseGeoCode<ExtendedGeoName>(_locationNames);

            _gavlePosistion = (60.674622, 17.141830);
            _uppsalaPosistion = (59.858562, 17.638927);
        }

        static void Main(string[] args)
        {

            // 1. Hitta de 10 närmsta platserna till Gävle (60.674622, 17.141830), sorterat på namn.
            ListaGavlePosition();

            // 2. Hitta alla platser inom 200 km radie till Uppsala (59.858562, 17.638927), sorterat på avstånd.
            Console.WriteLine("2. Uppsala");
            
            ListUppsalaPosition();
            // 3. Lista x platser baserat på användarinmatning.
        
        }
        static void ListUppsalaPosition()

        {

            var radius = 200 * 1000;
            var nearestUppsalaPosition = _reverseGeoCodingService.RadialSearch(_uppsalaPosistion.lat, _uppsalaPosistion.lng, radius, 50);

            nearestUppsalaPosition = nearestUppsalaPosition.OrderBy(x => x.DistanceTo(_uppsalaPosistion.lat, _uppsalaPosistion.lng));

            foreach (var potition in nearestUppsala)
            {
                var uppsalaDistance = potition.DistanceTo(lat, lng,);
            
            

            }
        }



        static void ListaGavlePosition()

        {
            var nearestGavle = _reverseGeoCodingService.RadialSearch(_gavlePosistion.lat, _gavlePosistion.lng, 10);

            nearestGavle = nearestGavle.OrderBy(p => p.Name);

            foreach (var position in nearestGavle)
            {
                Console.WriteLine($"{position.Name}, lat: {position.Latitude}, lng: {position.Longitude}");
            }
        }
    }
}
