<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class stateseeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('states')->insert([
            ['name' => 'Bács-Kiskun'],
            ['name' => 'Baranya'],
            ['name' => 'Békés'],
            ['name' => 'Borsod-Abaúj-Zemplén'],
            ['name' => 'Budapest'],
            ['name' => 'Csongrád'],
            ['name' => 'Fejér'],
            ['name' => 'Győr-Moson-Sopron'],
            ['name' => 'Hajdú-Bihar'],
            ['name' => 'Heves'],
            ['name' => 'Jász-Nagykun-Szolnok'],
            ['name' => 'Komárom-Esztergom'],
            ['name' => 'Nógrád'],
            ['name' => 'Pest'],
            ['name' => 'Somogy'],
            ['name' => 'Szabolcs-Szatmár-Bereg'],
            ['name' => 'Tolna'],
            ['name' => 'Vas'],
            ['name' => 'Veszprém'],
            ['name' => 'Zala']
        ]);
    }
}
