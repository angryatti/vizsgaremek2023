<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class UpdateUserRequest extends FormRequest
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
            'user_name' => 'sometimes|max:20|unique:users,user_name',
            'email' => 'sometimes|max:35|unique:users,email',
            'full_name' => 'sometimes|max:35',
            'phone_number' => 'sometimes|max:15',
        ];
    }
}
