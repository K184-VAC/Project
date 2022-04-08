<script>
    export default {
        data() {
            return {
                nariai: ""
            }
        }
    }
</script>
<template>
    <form class="mt-4 mb-4 ms-4">
        <div class="mb-3">
            <label for="name" class="form-label">Komandos pavadinimas</label>
            <input type="text" class="form-control w-25" id="name">
        </div>
            <div class="mb-3">
                <label for="disabledTextInput" class="form-label">Pridėti nariai</label>
                <input disabled type="text" id="disabledTextInput" class="form-control" :value="nariai">
            </div>
        <div class="mb-3">
            <label for="members" class="form-label">Komandos nariai</label>
            <select style="width: 20%" class="form-select mb-3">
                <option selected>Atidaryti narių sąrašą</option>
                <option value="1">Vardenis Pavardenis</option>
                <option value="2">Antanas Antanaitis</option>
                <option value="3">Petras Petraitis</option>
            </select>
            <button @click="" class="btn btn-primary">Pridėti</button>
        </div>
        <button type="submit" class="btn btn-primary">Sukurti</button>
    </form>
</template>
