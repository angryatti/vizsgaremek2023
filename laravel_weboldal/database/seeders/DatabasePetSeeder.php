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
            'species' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "dog.jpg",
            'description' => "A kiskutya két hete született, jövő héten elvihető.",
            'breed' => 1,
        ]);

 DB::table('pets')->insert([
            'pet_name' => 'Csípi',
            'born' => 2003,
            'species' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "dog.jpg",
            'description' => "A kiskutya két hete született, jövő héten nagy eséllyel elvihető.",
            'breed' => 31,
        ]);
    
        DB::table('pets')->insert([
            'pet_name' => 'Pannus',
            'born' => 2012,
            'species' => 'kutya', //nem listázott érték / unlisted,
            'breed' => 5,
            'gender' => 'Nőstény',
            'castrated' => true,
            'img_userdefine' => "dog.jpg",
            'description' => "A kislány kutya három hete született, ivartalanított, jövő héten elvihető.",
            
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Bogyóka',
            'born' => 2012,
            'species' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Nőstény',
            'castrated' => true,
            'img_userdefine' => "dog.jpg",
            'description' => "A kislány kutya két hónapja született, ivartalanított, azonnal elvihető.",
            'breed' => 1,
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Zeusz',
            'born' => 2014,
            'species' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => true,
            'img_userdefine' => "dog.jpg",
            'description' => "A kiskutya három hete született, ivartalanított, jövő héten elvihető.",
            'breed' => 12
        ]);


        DB::table('pets')->insert([
            'pet_name' => 'Mirci',
            'born' => 2017,
            'species' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Nőstény',
            'castrated' => true,
            'img_userdefine' => "cat.jpg",
            'description' => "Háromhetes. A cica ivartalanított és féregtelenítve!",
            'breed' => 12,
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Merkuri',
            'born' => 2018,
            'species' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "cat.jpg",
            'description' => "Kéthetes, jövő héten elvíhető, féregtelenítve!",
            'breed' => 35
          ]);

        DB::table('pets')->insert([
            'pet_name' => 'Picur',
            'born' => 2020,
            'species' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "cat.jpg",
            'description' => "Négyhetes, jövő héten elvíhető, féregtelenítve!",
            'breed' => 5
          ]);

        DB::table('pets')->insert([
            'pet_name' => 'Garfield',
            'born' => 2021,
            'species' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "cat.jpg",
            'description' => "Háromhetes, jövő héten elvíhető, féregtelenítve!",
            'breed' => 55
          ]);



          DB::table('pets')->insert([
            'pet_name' => 'Stuart Little',
            'born' => 2020,
            'species' => 'egyeb', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "others.jpg",
            'description' => "Háromhetes, jövő héten elvíhető",
            'breed' => 55
          ]);
          
        

    }
}
