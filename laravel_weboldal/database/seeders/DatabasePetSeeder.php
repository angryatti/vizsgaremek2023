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
            'description' => "A kiskutya két hete született, jövőhéten elvihető."
        ]);

        DB::table('pets')->insert([
            'pet_name' => 'Mirci',
            'breed' => 'macska', //nem listázott érték / unlisted,
            'gender' => 'Nőstény',
            'castrated' => true,
          //  'img_userdefine' => "mirci.jpg",
          'contact_info' => "Budapest XVII, Kisvárda utcában.",
            'description' => "Három hetes. A cica ivartalanított és féregtelenítve!"
        ]);

    }
}
