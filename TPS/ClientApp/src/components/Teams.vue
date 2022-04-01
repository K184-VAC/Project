<script setup lang="ts">
    interface Team {
        planning: string;
        standup: string;
        retro: string;
    }
    let plan = "Plannning 2022-03-21";
    let stand = "Standup 2022-03-23";
    let retro = "Retro 2022-03-03";

    const team1 = { planning: plan, standup: stand, retro: retro };
    const team2 = { planning: plan, standup: stand, retro: retro };
    const team3 = { planning: plan, standup: stand, retro: retro };
    const team4 = { planning: plan, standup: stand, retro: retro };

    //let team1: string = "Planning";
</script>
<template>
    <div class="mt-4 mb-4 ms-4">
        <router-link to="/teams/add" class="ml-3 btn btn-primary" tag="button">Sukurti komandą</router-link>
    </div>
    <div class="row">
        <div class="col-2 mt-4 mb-4 ms-4">
            <div class="list-group" id="list-tab" role="tablist">
                <a class="list-group-item list-group-item-action active" id="list-team1-list" data-bs-toggle="list" href="#list-team1" role="tab" aria-controls="list-team1">Komanda 1</a>
                <a class="list-group-item list-group-item-action" id="list-team2-list" data-bs-toggle="list" href="#list-team2" role="tab" aria-controls="list-team2">Komanda 2</a>
                <a class="list-group-item list-group-item-action" id="list-team3-list" data-bs-toggle="list" href="#list-team3" role="tab" aria-controls="list-team3">Komanda 3</a>
                <a class="list-group-item list-group-item-action" id="list-team4-list" data-bs-toggle="list" href="#list-team4" role="tab" aria-controls="list-team4">Komanda 4</a>
            </div>
        </div>
        <div class="col-8 mt-4 mb-4 ms-4">
            <div class="tab-content" id="nav-tabContent">
                <div class="tab-pane fade show active" id="list-team1" role="tabpanel" aria-labelledby="list-team1-list">
                    {{team1.planning}}<br>
                    {{team1.standup}}<br>
                    {{team1.retro}}<br>
                </div>
                <div class="tab-pane fade" id="list-team2" role="tabpanel" aria-labelledby="list-team2-list">
                    {{team2.planning}}<br>
                    {{team2.standup}}<br>
                    {{team2.retro}}<br>

                </div>
                <div class="tab-pane fade" id="list-team3" role="tabpanel" aria-labelledby="list-team3-list">
                    {{team3.planning}}<br>
                    {{team3.standup}}<br>
                    {{team3.retro}}<br>

                </div>
                <div class="tab-pane fade" id="list-team4" role="tabpanel" aria-labelledby="list-team4-list">
                    {{team4.planning}}<br>
                    {{team4.standup}}<br>
                    {{team4.retro}}<br>

                </div>
            </div>
        </div>
    </div>

</template>
