<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Support\Facades\Hash;

class LoginRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     *
     * @return bool
     */
    public function authorize()
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, mixed>
     */
    public function rules()
    {
        return [
            'username' => 'required',
            'password' => 'required'
        ];
    }

    public function getCredentials()
    {
        $username = $this->get('email');
        $password = $this->get('password');
        $password = Hash::make($password);
        if ($this->isEmail($username)) {
            return [
                'email' => $username,
                'password' => $password
            ];
        }

        return $this->only('username', 'password');
    }
}
