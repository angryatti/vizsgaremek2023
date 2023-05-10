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
            'breed' => 'Németjuhász',
        ]);

 DB::table('pets')->insert([
            'pet_name' => 'Csípi',
            'born' => 2003,
            'species' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "dog.jpg",
            'description' => "A kiskutya két hete született, jövő héten nagy eséllyel elvihető.",
            'breed' => "Keverék",
        ]);
    
        DB::table('pets')->insert([
            'pet_name' => 'Pannus',
            'born' => 2012,
            'species' => 'kutya', //nem listázott érték / unlisted,
            'breed' => "Szamojéd",
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
            'breed' => "Francia bulldog",
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Zeusz',
            'born' => 2014,
            'species' => 'kutya', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => true,
            'img_userdefine' => "dog.jpg",
            'description' => "A kiskutya három hete született, ivartalanított, jövő héten elvihető.",
            'breed' => "Alaszkai malamut"
        ]);


        DB::table('pets')->insert([
            'pet_name' => 'Mirci',
            'born' => 2017,
            'species' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Nőstény',
            'castrated' => true,
            'img_userdefine' => "cat.jpg",
            'description' => "Háromhetes. A cica ivartalanított és féregtelenítve!",
            'breed' => "Maine Coon",
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Merkuri',
            'born' => 2018,
            'species' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "cat.jpg",
            'description' => "Kéthetes, jövő héten elvíhető, féregtelenítve!",
            'breed' => "Amerikai drótszőrű"
          ]);

        DB::table('pets')->insert([
            'pet_name' => 'Picur',
            'born' => 2020,
            'species' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "cat.jpg",
            'description' => "Négyhetes, jövő héten elvíhető, féregtelenítve!",
            'breed' => "Bengáli"
          ]);

        DB::table('pets')->insert([
            'pet_name' => 'Garfield',
            'born' => 2021,
            'species' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "cat.jpg",
            'description' => "Háromhetes, jövő héten elvíhető, féregtelenítve!",
            'breed' => "Brit rövidszőrű"
          ]);



          DB::table('pets')->insert([
            'pet_name' => 'Stuart Little',
            'born' => 2020,
            'species' => 'egyeb', //nem listázott érték / unlisted,
            'gender' => 'Hím',
            'castrated' => false,
            'img_userdefine' => "others.jpg",
            'description' => "Háromhetes, jövő héten elvíhető",
            'breed' => "Egér"
          ]);
          
        

    }
}
