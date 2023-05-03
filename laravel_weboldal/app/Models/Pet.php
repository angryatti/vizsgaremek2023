<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Pet extends Model
{
    protected $table = 'pets';   

    /**
     * Get the advert associated with the Pet
     *
     * @return \Illuminate\Database\Eloquent\Relations\HasOne
     */
    public function advert()
    {
        return $this->hasOne(Advert::class);
    }
    protected $fillable = [
        'pet_name',
        'born',
        'breed', 
        'species',
        'gender',
        'castrated',
        'img_userdefine',
        'description',
    ];

    protected $guarded = [];

    public $timestamps = false;
}