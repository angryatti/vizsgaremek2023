<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class AdvertSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('adverts')->insert(
            [
                [
                    'user_id' => 1,
                    'pet_id' => 1,
                    'state_id' => 13, 
                    'contact_info' => 'Telefonon, hétvégén ne keressenek',
                ],
                [
                    'user_id' => 2,
                    'pet_id' => 4,
                    'state_id' => 13, 
                    'contact_info' => 'Telefonon, hétvégén ne keressenek',
                ],
                [
                    'user_id' => 4,
                    'pet_id' => 2,
                    'state_id' => 18, 
                    'contact_info' => 'Telefonon, hétvégén ne keressenek',
                ],
                [
                    'user_id' => 5,
                    'pet_id' => 3,
                    'state_id' => 13, 
                    'contact_info' => 'Telefonon, hétvégén ne keressenek',
                ],
                [
                    'user_id' => 3,
                    'pet_id' => 5,
                    'state_id' => 1, 
                    'contact_info' => 'Telefonon, hétvégén ne keressenek',
                ],
                [
                    'user_id' => 3,
                    'pet_id' => 6,
                    'state_id' => 1, 
                    'contact_info' => 'Telefonon, hétvégén ne keressenek',
                ],
                [
                    'user_id' => 3,
                    'pet_id' => 7,
                    'state_id' => 1, 
                    'contact_info' => 'Telefonon, hétvégén ne keressenek',
                ],
                [
                    'user_id' => 3,
                    'pet_id' => 8,
                    'state_id' => 1, 
                    'contact_info' => 'Telefonon, hétvégén ne keressenek',
                ],
                [
                    'user_id' => 3,
                    'pet_id' => 9,
                    'state_id' => 1, 
                    'contact_info' => 'Telefonon, hétvégén ne keressenek',
                ],
                [
                    'user_id' => 3,
                    'pet_id' => 10,
                    'state_id' => 1, 
                    'contact_info' => 'Telefonon, hétvégén ne keressenek',
                ],
            ]

        );
    }
}
