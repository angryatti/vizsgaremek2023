<?php

namespace App\Models;

// use Illuminate\Contracts\Auth\MustVerifyEmail;
use Illuminate\Foundation\Auth\User as Authenticatable;
use Illuminate\Notifications\Notifiable;
use Laravel\Sanctum\HasApiTokens;

class User extends Authenticatable
{
    use HasApiTokens, Notifiable;


    /**
     * Get all of the adverts for the User
     *
     * @return \Illuminate\Database\Eloquent\Relations\HasMany
     */
    public function adverts()
    {
        return $this->hasMany(Advert::class);
    }
    /**
     * The attributes that are mass assignable.
     *
     * @var array<int, string>
     */

    protected $table = 'users';

    protected $fillable = [
        'user_name',
        'email',
        'full_name',
        'password',
        'phone_number'
    ];

    /**
     * The attributes that should be hidden for serialization.
     *
     * @var array<int, string>
     */
    protected $hidden = [
        'password',
        'remember_token',
    ];

    public $timestamps = false;
    /**
     * The attributes that should be cast.
     *
     * @var array<string, string>
     */
}
