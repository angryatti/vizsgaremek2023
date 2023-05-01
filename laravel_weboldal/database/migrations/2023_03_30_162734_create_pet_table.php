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
            $table->integer('born')->nullable(false);
            $table->string('breed',20)->nullable(false);
            $table->foreignid('petbreed_id')->nullable();
            $table->string('gender',7)->nullable(false);
            $table->boolean('castrated')->nullable(false);
            $table->string('img_userdefine',100)->nullable(true);
            $table->text('description')->nullable(false);
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
