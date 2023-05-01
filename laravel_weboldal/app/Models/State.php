<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class State extends Model
{
    protected $table = 'states';


    /**
     * Get all of the cities for the State
     *
     * @return \Illuminate\Database\Eloquent\Relations\HasMany
     */
    public function adverts(){
        return $this->hasMany(Advert::class);
    }
}
