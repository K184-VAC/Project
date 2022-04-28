<script setup lang="ts">
    interface Team {
        id: number;
        name: string;
        NAD: NamesAndDescriptions[];
    }

    interface NamesAndDescriptions {
        names: string;
        descriptions: string;
    }

    var teamList: Team[] = [
        {
            id: 0,
            name: '',
            NAD: [
                {
                    names: '',
                    descriptions: ''
                }
            ]
        }
    ]
    // just for example
    for (let i = 0; i < 2; i++) {
        if (i == 0) {
            teamList[i].id = i + 1;
            teamList[i].name = 'Komanda ' + (i + 1);
            teamList[i].NAD = [
                {
                    names: 'Sandėliavimo sistema',
                    descriptions: 'Produktų pildymas, redagavimas, istrynimas, jų paieška ir likučio kiekio patikrinimas.'
                },
                {
                    names: 'El. parduotuvė',
                    descriptions: 'Vartotojo sąsaja, duomenų bazė, vartotojo valdymas, filtravimo ir rikiavimo funkcijos.'
                }];
        }
        else {
            const team: Team = {
                id: i + 1,
                name: 'Komanda ' + (i + 1),
                NAD: [
                    {
                        names: 'Duomenų bazė logistikos įmonei',
                        descriptions: 'Visos reikalingos CRUD funkcijos, validacija darbuotojų autorizavimui.'
                    },
                    {
                        names: 'Vartotojo sąsaja BLOG svetainei',
                        descriptions: 'Dizainas su stiliais pagal kliento užsakymą.'
                    },
                    {
                        names: 'El. parduotuvės svetainės palaikymas',
                        descriptions: 'Back-end optimizacija, dabartinių problemų pašalinimas, testavimas, serverio priežiūra.'
                    }
                ]
            };
            teamList.push(team);
        }
    }

</script>
<template>
    <div class="mt-4 mb-4 ms-4">
        <router-link to="#" class="ml-3 btn btn-primary" tag="button">Sukurti projektą</router-link>
    </div>
    <div class="row">
        <div class="col-2 mt-4 mb-4 ms-4">
            <div class="list-group" id="list-tab" role="tablist">
                <a v-for="team in teamList" class="list-group-item list-group-item-action d-flex justify-content-between align-items-center" data-bs-toggle="list" v-bind:href="'#list-team' + team.id" role="tab">
                    {{team.name}}
                    <span class="badge bg-warning rounded-pill">{{team.NAD.length}}</span>
                </a>
            </div>
        </div>
        <div class="col-8 mt-4 mb-4 ms-4">
            <div class="tab-content" id="nav-tabContent">
                <div v-for="team in teamList" class="tab-pane fade" :id="'list-team' + team.id" role="tabpanel">
                    <div>
                        <router-link to="#" class="ml-3 btn btn-warning" tag="button">Redaguoti</router-link>
                    </div>
                    <div class="pe-1">
                        <table class="table table-striped table-hover">
                            <thead class="table-light">
                                <tr>
                                    <th style="width: 16%">Pavadinimas</th>
                                    <th style="width: 30%">Aprašymas</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="dae in team.NAD">
                                    <td>{{dae.names}}</td>
                                    <td>{{dae.descriptions}}</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>
