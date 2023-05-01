<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class UserSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('users')->insert(
            [
                [
                    'user_name' => 'proba1',
                    'email' => 'proba1@proba.hu',
                    'phone_number' => '+36709999999', 
                    'full_name' => 'Kiss Ádám',
                    'password' => bcrypt('proba123'),
                ],
                [
                    'user_name' => 'proba2',
                    'email' => 'proba2@proba.hu',
                    'phone_number' => '+36709999999', 
                    'full_name' => 'Benk Dénes',
                    'password' => bcrypt('proba123'),
                ],
                [
                    'user_name' => 'proba3',
                    'email' => 'proba3@proba.hu',
                    'phone_number' => '+36709999999', 
                    'full_name' => 'Horváth Csaba',
                    'password' => bcrypt('proba123'),
                ],
                [
                    'user_name' => 'proba4',
                    'email' => 'proba4@proba.hu',
                    'phone_number' => '+36709999999', 
                    'full_name' => 'Homok Attila',
                    'password' => bcrypt('proba123'),
                ],
                [
                    'user_name' => 'proba5',
                    'email' => 'proba5@proba.hu',
                    'phone_number' => '+36709999999', 
                    'full_name' => 'Dávid Balázs',
                    'password' => bcrypt('proba123'),
                ],
            ]

        );
    }
}
