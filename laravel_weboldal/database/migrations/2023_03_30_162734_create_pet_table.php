<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('pets', function (Blueprint $table) {
            $table->id();
            $table->string('pet_name',35)->nullable(false);
            $table->string('breed',6)->nullable(false);
            
            $table->string('gender',7)->nullable(false);
            $table->boolean('castrated')->nullable(false);
            $table->string('img_userdefine',100)->nullable(true);
            $table->text('description')->nullable(false);
            $table->string('contact_info',200)->nullable(false);
            $table->integer('petbreed_id',false,false)->nullable(true);
       //     $table->foreignId('user_id')->references('id')->on('users');;

            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('pets');
    }
};
