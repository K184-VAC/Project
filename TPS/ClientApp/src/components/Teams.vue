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
        <button type="button" class="ml-3 btn btn-primary">Sukurti komandą</button>
    </div>
    <div class="row">
        <div class="col-2 mt-4 mb-4 ms-4">
            <div class="list-group" id="list-tab" role="tablist">
                <a class="list-group-item list-group-item-action active" id="list-home-list" data-bs-toggle="list" href="#list-home" role="tab" aria-controls="list-home">Team 1</a>
                <a class="list-group-item list-group-item-action" id="list-profile-list" data-bs-toggle="list" href="#list-profile" role="tab" aria-controls="list-profile">Team 2</a>
                <a class="list-group-item list-group-item-action" id="list-messages-list" data-bs-toggle="list" href="#list-messages" role="tab" aria-controls="list-messages">Team 3</a>
                <a class="list-group-item list-group-item-action" id="list-settings-list" data-bs-toggle="list" href="#list-settings" role="tab" aria-controls="list-settings">Team 4</a>
            </div>
        </div>
        <div class="col-8 mt-4 mb-4 ms-4">
            <div class="tab-content" id="nav-tabContent">
                <div class="tab-pane fade show active" id="list-home" role="tabpanel" aria-labelledby="list-home-list">
                    {{team1.planning}}<br>
                    {{team1.standup}}<br>
                    {{team1.retro}}<br>
                </div>
                <div class="tab-pane fade" id="list-profile" role="tabpanel" aria-labelledby="list-profile-list">
                    {{team2.planning}}<br>
                    {{team2.standup}}<br>
                    {{team2.retro}}<br>

                </div>
                <div class="tab-pane fade" id="list-messages" role="tabpanel" aria-labelledby="list-messages-list">
                    {{team3.planning}}<br>
                    {{team3.standup}}<br>
                    {{team3.retro}}<br>

                </div>
                <div class="tab-pane fade" id="list-settings" role="tabpanel" aria-labelledby="list-settings-list">
                    {{team4.planning}}<br>
                    {{team4.standup}}<br>
                    {{team4.retro}}<br>

                </div>
            </div>
        </div>
    </div>

</template>
