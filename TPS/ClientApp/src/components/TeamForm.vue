<script setup lang="ts">

</script>
<template>
    <form class="mt-4 mb-4 ms-4">
        <div class="mb-3">
            <label for="name" class="form-label">Komandos pavadinimas</label>
            <input type="text" class="form-control w-25" id="name">
        </div>
        <div class="mb-3">
            <label for="members" class="form-label">Komandos nariai</label>
            <div class="dropdown">
                <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                    Nariai
                </button>
                <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                    <li><a class="dropdown-item">Vardenis Pavardenis</a></li>
                    <li><a class="dropdown-item">Antanas Antanaitis</a></li>
                    <li><a class="dropdown-item">Petras Petraitis</a></li>
                </ul>
            </div>
        </div>
        <button type="submit" class="btn btn-primary">Sukurti</button>
    </form>
</template>
