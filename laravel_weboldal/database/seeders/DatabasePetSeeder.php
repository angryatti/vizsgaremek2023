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
            'img_userdefine' => "morzsi.jpg",
            'contact_info' => "Budapest, Nagymaros utca.",
            'description' => "A kiskutya két hete született, jövő héten elvihető.",
            'petbreed_id' => 1,
            'created_at' => '2022-12-09',
            'updated_at' => '2023-01-06'
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Csípi',
            'breed' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "csipi.jpg",
            'contact_info' => "Budapest, Nagymaros utca.",
            'description' => "A kiskutya két hete született, jövő héten nagy eséllyel elvihető.",
            'petbreed_id' => 31,
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Pannus',
            'breed' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Nőstény',
            'castrated' => true,
            'img_userdefine' => "pannus.jpg",
            'contact_info' => "Budapest, Nagy Lajos király útja.",
            'description' => "A kislány kutya három hete született, ivartalanított, jövő héten elvihető.",
            'petbreed_id' => 5,
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Bogyóka',
            'breed' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Nőstény',
            'castrated' => true,
            'img_userdefine' => "bogyoka.jpg",
            'contact_info' => "Budapest, Deák Ferenc tér",
            'description' => "A kislány kutya két hónapja született, ivartalanított, azonnal elvihető.",
            'petbreed_id' => 1,
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Zeusz',
            'breed' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => true,
            'img_userdefine' => "zeusz.jpg",
            'contact_info' => "Budapest, Deák Ferenc tér",
            'description' => "A kiskutya három hete született, ivartalanított, jövő héten elvihető.",
            'petbreed_id' => 12
        ]);


        DB::table('pets')->insert([
            'pet_name' => 'Mirci',
            'breed' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Nőstény',
            'castrated' => true,
            'img_userdefine' => "mirci.jpg",
            'contact_info' => "Budapest XVII, Kisvárda utcában.",
            'description' => "Háromhetes. A cica ivartalanított és féregtelenítve!",
            'petbreed_id' => 12,
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Merkuri',
            'breed' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "merkuri.jpg",
            'contact_info' => "2233 Ecser, Községháza",
            'description' => "Kéthetes, jövő héten elvíhető, féregtelenítve!",
            'petbreed_id' => 35
          ]);

        DB::table('pets')->insert([
            'pet_name' => 'Picur',
            'breed' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "picur.jpg",
            'contact_info' => "Pest megye",
            'description' => "Négyhetes, jövő héten elvíhető, féregtelenítve!",
            'petbreed_id' => 5
          ]);

        DB::table('pets')->insert([
            'pet_name' => 'Garfield',
            'breed' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "garfield.jpg",
            'contact_info' => "Pest megye",
            'description' => "Háromhetes, jövő héten elvíhető, féregtelenítve!",
            'petbreed_id' => 55
          ]);





    }
}
