<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class DatabasePetSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('pets')->insert([
            'pet_name' => 'Morzsi',
            'breed' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
          //  'img_userdefine' => "morzsi.jpg",
          'contact_info' => "Budapest, Nagymaros utca.",
            'description' => "A kiskutya két hete született, jövő héten elvihető."
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Csípi',
            'breed' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
          //  'img_userdefine' => "morzsi.jpg",
          'contact_info' => "Budapest, Nagymaros utca.",
            'description' => "A kiskutya két hete született, jövő héten nagy eséllyel elvihető."
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Pannus',
            'breed' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Nőstény',
            'castrated' => true,
          //  'img_userdefine' => "morzsi.jpg",
          'contact_info' => "Budapest, Nagy Lajos király útja.",
            'description' => "A kislány kutya három hete született, ivartalanított, jövő héten elvihető."
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Bogyóka',
            'breed' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Nőstény',
            'castrated' => true,
          //  'img_userdefine' => "morzsi.jpg",
          'contact_info' => "Budapest, Deák Ferenc tér",
            'description' => "A kislány kutya két hónapja született, ivartalanított, azonnal elvihető."
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Zeusz',
            'breed' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => true,
          //  'img_userdefine' => "morzsi.jpg",
          'contact_info' => "Budapest, Deák Ferenc tér",
            'description' => "A kiskutya három hete született, ivartalanított, jövő héten elvihető."
        ]);


        DB::table('pets')->insert([
            'pet_name' => 'Mirci',
            'breed' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Nőstény',
            'castrated' => true,
          //  'img_userdefine' => "mirci.jpg",
          'contact_info' => "Budapest XVII, Kisvárda utcában.",
            'description' => "Háromhetes. A cica ivartalanított és féregtelenítve!"
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Merkuri',
            'breed' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
          //  'img_userdefine' => "mirci.jpg",
          'contact_info' => "2233 Ecser, Községháza",
            'description' => "Kéthetes, jövő héten elvíhető, féregtelenítve!"
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Picur',
            'breed' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
          //  'img_userdefine' => "mirci.jpg",
          'contact_info' => "Pest megye",
            'description' => "Négyhetes, jövő héten elvíhető, féregtelenítve!"
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Garfield',
            'breed' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
          //  'img_userdefine' => "mirci.jpg",
          'contact_info' => "Pest megye",
            'description' => "Háromhetes, jövő héten elvíhető, féregtelenítve!"
        ]);





    }
}
