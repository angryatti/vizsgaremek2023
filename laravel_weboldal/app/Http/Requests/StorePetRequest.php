<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class StorePetRequest extends FormRequest
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
            'user_id' => 'required',
            'pet_name' => 'required',
            'born' =>'required',
            'species' => 'required',
            'breed' => 'required',
            'gender' => 'required',
            'castrated' => 'required|boolean',
            'img' => 'required',
            'description' => 'required',
            'state_id' => 'required',
            'contact_info' => 'required',
        ];
    }
}
