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
            'born' => 2012,
            'breed' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "dog.jpg",
            'description' => "A kiskutya két hete született, jövő héten elvihető.",
            'petbreed_id' => 1,
        ]);

 DB::table('pets')->insert([
            'pet_name' => 'Csípi',
            'born' => 2003,
            'breed' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "dog.jpg",
            'description' => "A kiskutya két hete született, jövő héten nagy eséllyel elvihető.",
            'petbreed_id' => 31,
        ]);
    
        DB::table('pets')->insert([
            'pet_name' => 'Pannus',
            'born' => 2012,
            'breed' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Nőstény',
            'castrated' => true,
            'img_userdefine' => "dog.jpg",
            'description' => "A kislány kutya három hete született, ivartalanított, jövő héten elvihető.",
            'petbreed_id' => 5,
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Bogyóka',
            'born' => 2012,
            'breed' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Nőstény',
            'castrated' => true,
            'img_userdefine' => "dog.jpg",
            'description' => "A kislány kutya két hónapja született, ivartalanított, azonnal elvihető.",
            'petbreed_id' => 1,
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Zeusz',
            'born' => 2014,
            'breed' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => true,
            'img_userdefine' => "dog.jpg",
            'description' => "A kiskutya három hete született, ivartalanított, jövő héten elvihető.",
            'petbreed_id' => 12
        ]);


        DB::table('pets')->insert([
            'pet_name' => 'Mirci',
            'born' => 2017,
            'breed' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Nőstény',
            'castrated' => true,
            'img_userdefine' => "cat.jpg",
            'description' => "Háromhetes. A cica ivartalanított és féregtelenítve!",
            'petbreed_id' => 12,
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Merkuri',
            'born' => 2018,
            'breed' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "cat.jpg",
            'description' => "Kéthetes, jövő héten elvíhető, féregtelenítve!",
            'petbreed_id' => 35
          ]);

        DB::table('pets')->insert([
            'pet_name' => 'Picur',
            'born' => 2020,
            'breed' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "cat.jpg",
            'description' => "Négyhetes, jövő héten elvíhető, féregtelenítve!",
            'petbreed_id' => 5
          ]);

        DB::table('pets')->insert([
            'pet_name' => 'Garfield',
            'born' => 2021,
            'breed' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "cat.jpg",
            'description' => "Háromhetes, jövő héten elvíhető, féregtelenítve!",
            'petbreed_id' => 55
          ]);



          DB::table('pets')->insert([
            'pet_name' => 'Stuart Little',
            'born' => 2020,
            'breed' => 'egyeb', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "others.jpg",
            'description' => "Háromhetes, jövő héten elvíhető"
           // 'petbreed_id' => 55
          ]);
          
        

    }
}
