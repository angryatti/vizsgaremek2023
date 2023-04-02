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
            'pet_name' => "Morzsi",
            'gender' => 'Hím',
            'castrated' => false,
          //  'img_userdefine' => "morzsi.jpg",
          'contact_info' => "Nagymaros utca 15.",
            'description' => "A kiskutya két hete született, jövőhéten elvihető"
        ]);
    }
}
